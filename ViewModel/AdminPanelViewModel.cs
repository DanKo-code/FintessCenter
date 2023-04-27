using FitnessCenter.BD.EntitiesBD;
using FitnessCenter.BD.EntitiesBD.Repositories;
using FitnessCenter.Core;
using FitnessCenter.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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
        public ObservableCollection<AbonementModel> AbonementsList { get; set; }

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
        private AbonementModel _selectedAbonement;

        public AbonementModel SelectedProducts
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
            AbonementModel abonement = new AbonementModel(temp);

            SelectedProducts = new AbonementModel(new Abonements("", "", "", "", 0, 0));

            AbonementsList.Add(abonement);
            context.AbonementRepo.AddAbonement(temp);

            
        }
        #endregion

        #region Deselect 
        public ICommand Deselect { get; }

        private bool CanDeselectCommand(object p)
        {
            foreach (AbonementModel item in AbonementsList)
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
            SelectedProducts = new AbonementModel(new Abonements("", "", "", "", 0, 0));

            AbonementsList.Add(SelectedProducts);
            AbonementsList.RemoveAt(AbonementsList.Count - 1);


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
            AbonementsList.Remove(SelectedProducts);
            context.AbonementRepo.RemoveAbonement(new Abonements(SelectedProducts.Title, SelectedProducts.Age, SelectedProducts.Validity, SelectedProducts.VisitingTime, SelectedProducts.Amount, SelectedProducts.Price));
        }
        #endregion

        #endregion

        public AdminPanelViewModel()
        {
            AddAbonement = new RelayCommand(OnAddAbonementCommand, CanAddAbonementCommand);
            Deselect = new RelayCommand(OnDeselectCommand, CanDeselectCommand);
            RemoveAbonement = new RelayCommand(OnRemoveAbonementCommand, CanRemoveAbonementCommand);

            //сразу загрузил даынне
            context = new UnitOfWork();

            //заполнил смотрящего //TODO добавить 
            AbonementsList = new ObservableCollection<AbonementModel>(context.AbonementRepo.GetAllAbonements());

            //на начальном этапе
            SelectedProducts = new AbonementModel(new Abonements("", "", "", "", 0, 0));





        }
    }
}
