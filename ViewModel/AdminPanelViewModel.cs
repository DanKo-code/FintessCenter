using FitnessCenter.BD.EntitiesBD;
using FitnessCenter.BD.EntitiesBD.Repositories;
using FitnessCenter.Core;
using FitnessCenter.Views.Windows.Main.UserControls.AdminPanel;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FitnessCenter.ViewModel
{
    internal class AdminPanelViewModel : ObservableObject
    {
        //EF
        private UnitOfWork context;

        //Ебанутая система
        bool canAdd = true;

        //Список абонементов
        public ObservableCollection<Abonements> AbonementsList { get; set; }
        public ObservableCollection<Abonements> SearchedList { get; set; }

        //Список заказов
        private ObservableCollection<Orders> _ordersList;

        public ObservableCollection<Orders> OrdersList
        {
            get => _ordersList;

            set
            {
                if (_ordersList != value)
                {
                    _ordersList = value;
                    OnPropertyChanged(nameof(OrdersList));
                }
            }
        }

        #region Accessors (helpers for ui design)

        #region NewServiceName
        private string _newServiceName;

        public string NewServiceName
        {
            get => _newServiceName;

            set
            {
                if (_newServiceName != value)
                {
                    _newServiceName = value;
                    OnPropertyChanged(nameof(NewServiceName));
                }
            }
        }
        #endregion

        #region SelectedServices
        private IEnumerable _selectedServices;

        public IEnumerable SelectedServices
        {
            get => _selectedServices;

            set
            {
                if (_selectedServices != value)
                {
                    _selectedServices = value;
                    OnPropertyChanged(nameof(SelectedServices));
                }
            }
        }
        #endregion

        #region ServicesList
        private List<string> _servicesList = new List<string> { "Бассейн", "Сауна", "Тренажерный зал" };

        public List<string> ServicesList
        {
            get => _servicesList;

            set
            {
                if (_servicesList != value)
                {
                    _servicesList = value;
                    OnPropertyChanged(nameof(ServicesList));
                }
            }
        }
        #endregion

        #region AbonementTitle
        private List<Abonements> _abonementTitle;

        public List<Abonements> AbonementTitle
        {
            get => _abonementTitle;

            set
            {
                if (_abonementTitle != value)
                {
                    _abonementTitle = value;
                    OnPropertyChanged(nameof(AbonementTitle));
                }
            }
        }
        #endregion

        #region BottomAbonementsPanelVisibility
        private Visibility _bottomAbonementsPanelVisibility;

        public Visibility BottomAbonementsPanelVisibility
        {
            get => _bottomAbonementsPanelVisibility;

            set
            {
                if (_bottomAbonementsPanelVisibility != value)
                {
                    _bottomAbonementsPanelVisibility = value;
                    OnPropertyChanged(nameof(BottomAbonementsPanelVisibility));
                }
            }
        }
        #endregion

        #region SelectedProducts
        private Abonements _selectedAbonement;

        public Abonements SelectedProducts
        {
            get => _selectedAbonement;

            set
            {
                if (value != null && _selectedAbonement != value)
                {
                    _selectedAbonement = value;
                    OnPropertyChanged(nameof(SelectedProducts));
                }
            }
        }
        #endregion

        #region SelectedOrders
        private Orders _selectedOrders;

        public Orders SelectedOrders
        {
            get => _selectedOrders;

            set
            {
                if (value != null && _selectedOrders != value)
                {
                    _selectedOrders = value;
                    OnPropertyChanged(nameof(SelectedOrders));
                }
            }
        }
        #endregion

        #region SearchString
        private string _searchString;

        public string SearchString
        {
            get => _searchString;

            set
            {
                if (_searchString != value)
                {
                    _searchString = value;
                    OnPropertyChanged(nameof(SearchString));
                }
            }
        }
        #endregion

        #region AdminListView
        private string _adminListView;

        public string AdminListView
        {
            get => _adminListView;

            set
            {
                if (_adminListView != value)
                {
                    _adminListView = value;
                    OnPropertyChanged(nameof(AdminListView));
                }
            }
        }
        #endregion

        #region AbonementsPanelVisibility
        private Visibility _abonementsPanelVisibility = Visibility.Visible;

        public Visibility AbonementsPanelVisibility
        {
            get => _abonementsPanelVisibility;

            set
            {
                if (_abonementsPanelVisibility != value)
                {
                    _abonementsPanelVisibility = value;
                    OnPropertyChanged(nameof(AbonementsPanelVisibility));
                }
            }
        }
        #endregion

        #region OrdersPanelVisibility
        private Visibility _ordersPanelVisibility = Visibility.Collapsed;

        public Visibility OrdersPanelVisibility
        {
            get => _ordersPanelVisibility;

            set
            {
                if (_ordersPanelVisibility != value)
                {
                    _ordersPanelVisibility = value;
                    OnPropertyChanged(nameof(OrdersPanelVisibility));
                }
            }
        }
        #endregion

        #region AbonementsListVisibility
        private Visibility _abonementsListVisibility = Visibility.Visible;

        public Visibility AbonementsListVisibility
        {
            get => _abonementsListVisibility;

            set
            {
                if (_abonementsListVisibility != value)
                {
                    _abonementsListVisibility = value;
                    OnPropertyChanged(nameof(AbonementsListVisibility));
                }
            }
        }
        #endregion

        #region OrdersListVisibility
        private Visibility _ordersListVisibility = Visibility.Collapsed;

        public Visibility OrdersListVisibility
        {
            get => _ordersListVisibility;

            set
            {
                if (_ordersListVisibility != value)
                {
                    _ordersListVisibility = value;
                    OnPropertyChanged(nameof(OrdersListVisibility));
                }
            }
        }
        #endregion

        #endregion



        #region Commands

        #region AddService 
        public ICommand AddService { get; }

        private bool CanAddServiceCommand(object p)
        {
            return true;
        }

        private void OnAddServiceCommand(object p)
        {
            ServicesList.Add(NewServiceName);
            //OnPropertyChanged("SelectedServices");
        }
        #endregion

        #region ApproveOrder 
        public ICommand ApproveOrder { get; }

        private bool CanApproveOrderCommand(object p)
        {
            return SelectedOrders != null;
        }

        private void OnApproveOrderCommand(object p)
        {
            context.OrderRepo.FindById(SelectedOrders.Id).Status = 1;

            context.Save();

            OrdersList.Remove(SelectedOrders);

            //********************************Отправка на почту**************************************************************

            MessageBox.Show("Начало отправки!");
            var mail = Helpers.SMTP.CreateMail("FitnessCenter", Helpers.CurrentClient.adminEmail, Helpers.CurrentClient.client.Email, $"Заказ!", $"<b>Ваш заказ</b><br><br>{SelectedOrders.Abonement.ToString()} <br><b>Статуc:</b> одобрен! :)");

            Helpers.SMTP.SendMail("smtp.gmail.com", 587, Helpers.CurrentClient.adminEmail, Helpers.CurrentClient.adminPass, mail);

            MessageBox.Show("Отправка на почту");
        }
        #endregion

        #region RejectOrder 
        public ICommand RejectOrder { get; }

        private bool CanRejectOrderCommand(object p)
        {
            return SelectedOrders != null;
        }

        private void OnRejectOrderCommand(object p)
        {
            context.OrderRepo.FindById(SelectedOrders.Id).Status = 2;

            context.Save();

            OrdersList.Remove(SelectedOrders);

            //********************************Отправка на почту**************************************************************

            MessageBox.Show("Начало отправки!");
            var mail = Helpers.SMTP.CreateMail("FitnessCenter", Helpers.CurrentClient.adminEmail, Helpers.CurrentClient.client.Email, $"Заказ!", $"<b>Ваш заказ</b><br><br>{SelectedOrders.Abonement.ToString()} <br><b>Статуc:</b> отклонен! :)");

            Helpers.SMTP.SendMail("smtp.gmail.com", 587, Helpers.CurrentClient.adminEmail, Helpers.CurrentClient.adminPass, mail);

            MessageBox.Show("Отправка на почту");
        }
        #endregion

        #region AddAbonement
        public ICommand AddAbonement { get; }

        private bool CanAddAbonementCommand(object p)
        {
            return canAdd;
        }

        private void OnAddAbonementCommand(object p)
        {
            //Взять поля из формы
            string title = SelectedProducts.Title;
            int age = SelectedProducts.Age;
            string validity = SelectedProducts.Validity;
            string visitingTime = SelectedProducts.VisitingTime;
            int amount = SelectedProducts.Amount;
            int price = SelectedProducts.Price;
            string photo = SelectedProducts.Photo;

            //Abonements temp = new Abonements(title, age, validity, visitingTime, amount, price, photo);
            Abonements temp = new Abonements { Id = new Guid(), Title = title, Age = age, Validity = validity, VisitingTime = visitingTime, Amount = amount, Price = price, Photo = photo };
            
            SelectedProducts = new Abonements();

            AbonementsList.Add(temp);
            SearchedList.Add(temp);
            context.AbonementRepo.AddAbonement(temp);

            
        }
        #endregion

        #region Deselect 
        public ICommand Deselect { get; }

        private bool CanDeselectCommand(object p)
        {
            foreach (Abonements item in AbonementsList)
            {
                if(SelectedProducts.Equals(item))
                {
                    canAdd = false;
                    break;
                }

                    
            }

            return !canAdd;
        }

        private void OnDeselectCommand(object p)
        {
            SelectedProducts = new Abonements();

            AbonementsList.Add(SelectedProducts);
            AbonementsList.RemoveAt(AbonementsList.Count - 1);

            SearchedList.Add(SelectedProducts);
            SearchedList.RemoveAt(SearchedList.Count - 1);


            canAdd = true;
        }
        #endregion

        #region RemoveAbonement
        public ICommand RemoveAbonement { get; }

        private bool CanRemoveAbonementCommand(object p)
        {
            return !canAdd;
        }

        private void OnRemoveAbonementCommand(object p)
        {
            //TODO 2
            AbonementsList.Remove(SelectedProducts);
            SearchedList.Remove(SelectedProducts);
            context.AbonementRepo.RemoveAbonement(SelectedProducts);
        }
        #endregion

        #region SearchAbonementByName
        public ICommand SearchAbonementByName { get; }

        private bool CanSearchAbonementByNameCommand(object p)
        {
            //return !canAdd;

            return true;
        }

        private void OnSearchAbonementByNameCommand(object p)
        {
           string pattern = SearchString;

            SearchedList.Clear();

            foreach (Abonements abonement in AbonementsList)
            {
                if (Regex.IsMatch(abonement.Title, pattern))
                {
                    SearchedList.Add(abonement);
                }
            }
        }
        #endregion

        #region SortAbonementByName
        public ICommand SortAbonementByName { get; }

        private bool CanSortAbonementByNameCommand(object p)
        {
            //return !canAdd;

            return true;
        }

        private void OnSortAbonementByNameCommand(object p)
        {
            var temp = SearchedList.OrderBy(x => x.Title).ToList();

            SearchedList.Clear();

            foreach (var item in temp)
            {
                SearchedList.Add(item);
            } 
        }
        #endregion

        #region SetPhoto 
        public ICommand SetPhoto { get; }

        private bool CanSetPhotoCommand(object p)
        {
            return true;
        }
        private void OnSetPhotoCommand(object p)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image|*.jpg;*.jpeg;*.png;";
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    SelectedProducts.Photo = openFileDialog.FileName;
                }
                catch
                {
                    MessageBox.Show("Выберите файл подходящего формата.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        #endregion

        #region SaveAllChanges
        public ICommand SaveAllChanges { get; }

        private bool CanSaveAllChangesCommand(object p)
        {
            return true;
        }
        private void OnSaveAllChangesCommand(object p)
        {
            context.AbonementRepo.SaveAllChanges(AbonementsList.ToList());

            Helpers.CurrentClient.abonements = AbonementsList.ToList();

            MessageBox.Show("Все удачно сохранено!");
        }
        #endregion


        #region ShowAbonementsPanel 
        public ICommand ShowAbonementsPanel { get; }

        private bool CanShowAbonementsPanelCommand(object p)
        {
            return true;
        }
        private void OnShowAbonementsPanelCommand(object p)
        {
            AbonementsPanelVisibility = Visibility.Visible;
            OrdersPanelVisibility = Visibility.Collapsed;

            AbonementsListVisibility = Visibility.Visible;
            OrdersListVisibility = Visibility.Collapsed;

            BottomAbonementsPanelVisibility = Visibility.Visible;
        }
        #endregion

        #region ShowOrdersPanel 
        public ICommand ShowOrdersPanel { get; }

        private bool CanShowOrdersPanelCommand(object p)
        {
            return true;
        }
        private void OnShowOrdersPanelCommand(object p)
        {
            OrdersPanelVisibility = Visibility.Visible;
            AbonementsPanelVisibility= Visibility.Collapsed;

            OrdersListVisibility = Visibility.Visible;
            AbonementsListVisibility = Visibility.Collapsed;
            BottomAbonementsPanelVisibility = Visibility.Collapsed;

            OrdersList = new ObservableCollection<Orders>(context.OrderRepo.GetAllOrder());
        }
        #endregion

        #endregion

        public AdminPanelViewModel()
        {
            AddService = new RelayCommand(OnAddServiceCommand, CanAddServiceCommand);

            AddAbonement = new RelayCommand(OnAddAbonementCommand, CanAddAbonementCommand);
            Deselect = new RelayCommand(OnDeselectCommand, CanDeselectCommand);
            RemoveAbonement = new RelayCommand(OnRemoveAbonementCommand, CanRemoveAbonementCommand);
            SearchAbonementByName = new RelayCommand(OnSearchAbonementByNameCommand, CanSearchAbonementByNameCommand);

            SortAbonementByName = new RelayCommand(OnSortAbonementByNameCommand, CanSortAbonementByNameCommand);

            SetPhoto = new RelayCommand(OnSetPhotoCommand, CanSetPhotoCommand);

            SaveAllChanges = new RelayCommand(OnSaveAllChangesCommand, CanSaveAllChangesCommand);

            ShowAbonementsPanel = new RelayCommand(OnShowAbonementsPanelCommand, CanShowAbonementsPanelCommand);

            ShowOrdersPanel = new RelayCommand(OnShowOrdersPanelCommand, CanShowOrdersPanelCommand);

            ApproveOrder = new RelayCommand(OnApproveOrderCommand, CanApproveOrderCommand);

            //сразу загрузил даынне
            context = new UnitOfWork();

            //заполнил смотрящего
            AbonementsList = new ObservableCollection<Abonements>(context.AbonementRepo.GetAllAbonements());

            SearchedList = new ObservableCollection<Abonements>(context.AbonementRepo.GetAllAbonements());

            //на начальном этапе
            SelectedProducts = new Abonements();

            OrdersList = new ObservableCollection<Orders>(context.OrderRepo.GetAllOrder());

            RejectOrder = new RelayCommand(OnRejectOrderCommand, CanRejectOrderCommand);
        }
    }
}