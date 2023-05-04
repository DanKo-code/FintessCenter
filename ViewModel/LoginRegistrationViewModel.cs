using FitnessCenter.BD;
using FitnessCenter.BD.EntitiesBD;
using FitnessCenter.BD.EntitiesBD.Repositories;
using FitnessCenter.Core;
using FitnessCenter.Helpers;
using FitnessCenter.Views.Windows.LoginRegistration;
using FitnessCenter.Views.Windows.Main;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace FitnessCenter.ViewModel
{
    internal class LoginRegistrationViewModel : ObservableObject
    {
        private UnitOfWork context;

        #region Accessors (helpers for ui design)

        #region SignInLogin
        private string _signInLogin;

        public string SignInLogin
        {
            get => _signInLogin;

            set
            {
                if (_signInLogin != value)
                {
                    _signInLogin = value;
                    OnPropertyChanged(nameof(SignInLogin));
                }
            }
        }
        #endregion

        #region SignInPassword
        private string _signInPassword;

        public string SignInPassword
        {
            get => _signInPassword;

            set
            {
                if (_signInPassword != value)
                {
                    _signInPassword = value;
                    OnPropertyChanged(nameof(SignInPassword));
                }
            }
        }
        #endregion

        #region NewClient
        //public Clients _newClient = new Clients("", "", "", "", "", "");
        public Clients _newClient = new Clients { Id = new Guid(), Email = "", Login = "", Name = "", Password = "", Phone ="", Role=0, SurName="" };

        public Clients NewClient
        {
            get => _newClient;

            set
            {
                if (_newClient != value)
                {
                    _newClient = value;
                    OnPropertyChanged(nameof(NewClient));
                }
            }
        }

        #endregion

        #region LoginVisibility
        private Visibility _loginVisibility = Visibility.Visible;

        public Visibility LoginVisibility
        {
            get => _loginVisibility;

            set
            {
                if (_loginVisibility != value)
                {
                    _loginVisibility = value;
                    OnPropertyChanged(nameof(LoginVisibility));
                }
            }
        }
        #endregion

        #region RegisterVisibility
        private Visibility _registerVisibility = Visibility.Collapsed;

        public Visibility RegisterVisibility
        {
            get => _registerVisibility;

            set
            {
                if (_registerVisibility != value)
                {
                    _registerVisibility = value;
                    OnPropertyChanged(nameof(RegisterVisibility));
                }
            }
        }
        #endregion

        //Для регистрации

        #region RegisterNameStyle
        private Brush _registerNameStyle;

        public Brush RegisterNameStyle
        {
            get => _registerNameStyle;

            set
            {
                if (_registerNameStyle != value)
                {
                    _registerNameStyle = value;
                    OnPropertyChanged(nameof(RegisterNameStyle));
                }
            }
        }
        #endregion

        #endregion

        #region Commands

        #region ShowLogin
        public ICommand ShowLoginCommand { get; }

        private bool CanShowLoginCommand(object p) => true;

        private void OnShowLoginCommand(object p)
        {
            LoginVisibility = Visibility.Visible;
            RegisterVisibility = Visibility.Collapsed;
        }
        #endregion

        #region ShowRegister
        public ICommand ShowRegisterCommand { get; }

        private bool CanShowRegisterCommand(object p) => true;

        private void OnShowRegisterCommand(object p)
        {
            LoginVisibility = Visibility.Collapsed;
            RegisterVisibility = Visibility.Visible;
        }
        #endregion

        private void GoMain(Clients client)
        {
            CurrentClient.client = client;

            Main main = new Main(client);
            main.Show();

            foreach (Window window in Application.Current.Windows)
            {
                if (window is LoginRegistration)
                {
                    window.Close();
                    break;
                }
            }

        }

        //Для регистрации

        #region CheckName
        public ICommand CheckName { get; }

        private bool CanCheckNameCommand(object p) => true;

        private void OnCheckNameCommand(object p)
        {


            if (!Regex.IsMatch(NewClient.Name, "^[A-Za-zА-Яа-я]+$"))
            {
                RegisterNameStyle = Brushes.Red;
                return;
            }

            RegisterNameStyle = Brushes.White;
        }
        #endregion

        #region Register
        public ICommand Register { get; }

        private bool CanRegisterCommand(object p) => true;

        private void OnRegisterCommand(object p)
        {
            context.ClientRepo.AddClient(NewClient);

            //TODO Проверка, есть ли такой логин в бд или нет

            OnShowLoginCommand(null);

            MessageBox.Show("Милости просим, бродяга ;)");
        }
        #endregion

        #region SignIn
        public ICommand SignIn { get; }

        private bool CanSignInCommand(object p) => true;

        private void OnSignInCommand(object p)
        {
            Clients temp;

            if (!context.ClientRepo.CheckLogin(SignInLogin))
            {
                MessageBox.Show("Неверный логин!");
                return;
            }

            temp = context.ClientRepo.CheckPassword(SignInLogin, SignInPassword);

            if (temp == null)
            {
                MessageBox.Show("Неверный пароль!");
                return;
            }

            MessageBox.Show("Заходи, внучёк");

            ////////////////////////////////////////////////////
            ///
            //CurrentClient.client = temp;

            //var test = CurrentClient.client;

            //MessageBox.Show("Начало отправки!");
            //var mail = SMTP.CreateMail("FitnessCenter", "ilyinnik3@gmail.com", "danik2003globin@gmail.com", "Новая тема", "Ты зашел, голубчик :)");

            //SMTP.SendMail("smtp.gmail.com", 587, "ilyinnik3@gmail.com", "aojiuhowjilqvtnb", mail);
            ////////////////////////////////////////////////////

            GoMain(temp);
        }
        #endregion

        
        #endregion

        public LoginRegistrationViewModel()
        {
            ShowLoginCommand = new RelayCommand(OnShowLoginCommand, CanShowLoginCommand);
            ShowRegisterCommand = new RelayCommand(OnShowRegisterCommand, CanShowRegisterCommand);
            

            //Проверка валидности при регистрации

            CheckName = new RelayCommand(OnCheckNameCommand, CanCheckNameCommand);

            //Сама регистрация
            Register = new RelayCommand(OnRegisterCommand, CanRegisterCommand);

            context = new UnitOfWork();

            //Для входа

            SignIn = new RelayCommand(OnSignInCommand, CanSignInCommand);

            Helpers.CurrentClient.abonements = context.AbonementRepo.GetAllAbonements();

        }
    }
}
