using FitnessCenter.BD.EntitiesBD;
using FitnessCenter.BD.EntitiesBD.Repositories;
using FitnessCenter.Core;
using FitnessCenter.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

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
            string age = SelectedProducts.Age;
            string validity = SelectedProducts.Validity;
            string visitingTime = SelectedProducts.VisitingTime;
            int amount = SelectedProducts.Amount;
            int price = SelectedProducts.Price;

            Abonements temp = new Abonements(title, age, validity, visitingTime, amount, price);
            
            SelectedProducts = new Abonements("", "", "", "", 0, 0);

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
            SelectedProducts = new Abonements("", "", "", "", 0, 0);

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

        #endregion

        public AdminPanelViewModel()
        {
            AddAbonement = new RelayCommand(OnAddAbonementCommand, CanAddAbonementCommand);
            Deselect = new RelayCommand(OnDeselectCommand, CanDeselectCommand);
            RemoveAbonement = new RelayCommand(OnRemoveAbonementCommand, CanRemoveAbonementCommand);
            SearchAbonementByName = new RelayCommand(OnSearchAbonementByNameCommand, CanSearchAbonementByNameCommand);

            //сразу загрузил даынне
            context = new UnitOfWork();

            //заполнил смотрящего //TODO добавить 
            AbonementsList = new ObservableCollection<Abonements>(context.AbonementRepo.GetAllAbonements());

            SearchedList = new ObservableCollection<Abonements>(context.AbonementRepo.GetAllAbonements());

            //на начальном этапе
            SelectedProducts = new Abonements("", "", "", "", 0, 0);





        }
    }
}
