using FitnessCenter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FitnessCenter.ViewModel
{
    internal class LoginRegistrationViewModel : ObservableObject
    {
        #region Accessors (helpers for ui design)

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
            RegisterVisibility = Visibility.Visible;
            LoginVisibility = Visibility.Collapsed;
        }
        #endregion

        #endregion

        public LoginRegistrationViewModel()
        {
            ShowLoginCommand = new RelayCommand(OnShowLoginCommand, CanShowLoginCommand);
            ShowRegisterCommand = new RelayCommand(OnShowRegisterCommand, CanShowRegisterCommand);
        }
    }
}
