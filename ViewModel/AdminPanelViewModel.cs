using FitnessCenter.BD.EntitiesBD;
using FitnessCenter.BD.EntitiesBD.Repositories;
using FitnessCenter.Core;
using FitnessCenter.Views.Windows.Main.UserControls.AdminPanel;
using Microsoft.Win32;
using System;
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
        ResourceDictionary GridPanelsDict = Application.Current.Resources.MergedDictionaries.FirstOrDefault(d => d.Source?.OriginalString == "/Resources/AdminPanelView/AdminPanelView.xaml");

        //EF
        private UnitOfWork context;

        //Ебанутая система
        bool canAdd = true;

        //Список абонементов
        public ObservableCollection<Abonements> AbonementsList { get; set; }
        public ObservableCollection<Abonements> SearchedList { get; set; }

        #region Accessors (helpers for ui design)

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

        #region AdminPanelGridView
        private GridView _adminPanelGridView;

        public GridView AdminPanelGridView
        {
            get => _adminPanelGridView;

            set
            {
                if (_adminPanelGridView != value)
                {
                    _adminPanelGridView = value;
                    OnPropertyChanged(nameof(AdminPanelGridView));
                }
            }
        }
        #endregion

        #endregion



        #region Commands

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

            Abonements temp = new Abonements(title, age, validity, visitingTime, amount, price, photo);
            
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

            //ResourceDictionary GridPanelsDict = Application.Current.Resources.MergedDictionaries.FirstOrDefault(d => d.Source?.OriginalString == "/Resources/AdminPanelView/AdminPanelView.xaml");

            AdminPanelGridView = (GridView)GridPanelsDict["AbonementsGridView"];


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

            //ResourceDictionary GridPanelsDict = Application.Current.Resources.MergedDictionaries.FirstOrDefault(d => d.Source?.OriginalString == "/Resources/AdminPanelView/AdminPanelView.xaml");

            AdminPanelGridView = (GridView)GridPanelsDict["OrdersGridView"];
        }
        #endregion

        #endregion

        public AdminPanelViewModel()
        {
            AddAbonement = new RelayCommand(OnAddAbonementCommand, CanAddAbonementCommand);
            Deselect = new RelayCommand(OnDeselectCommand, CanDeselectCommand);
            RemoveAbonement = new RelayCommand(OnRemoveAbonementCommand, CanRemoveAbonementCommand);
            SearchAbonementByName = new RelayCommand(OnSearchAbonementByNameCommand, CanSearchAbonementByNameCommand);

            SortAbonementByName = new RelayCommand(OnSortAbonementByNameCommand, CanSortAbonementByNameCommand);

            SetPhoto = new RelayCommand(OnSetPhotoCommand, CanSetPhotoCommand);

            SaveAllChanges = new RelayCommand(OnSaveAllChangesCommand, CanSaveAllChangesCommand);

            ShowAbonementsPanel = new RelayCommand(OnShowAbonementsPanelCommand, CanShowAbonementsPanelCommand);

            ShowOrdersPanel = new RelayCommand(OnShowOrdersPanelCommand, CanShowOrdersPanelCommand);

            //ChangeAdminPanelGridView = new RelayCommand(OnChangeAdminPanelGridViewCommand, CanChangeAdminPanelGridViewCommand);

            //сразу загрузил даынне
            context = new UnitOfWork();

            //заполнил смотрящего
            AbonementsList = new ObservableCollection<Abonements>(context.AbonementRepo.GetAllAbonements());

            SearchedList = new ObservableCollection<Abonements>(context.AbonementRepo.GetAllAbonements());

            //на начальном этапе
            SelectedProducts = new Abonements();

            AdminPanelGridView = (GridView)GridPanelsDict["AbonementsGridView"];

        }
    }
}
