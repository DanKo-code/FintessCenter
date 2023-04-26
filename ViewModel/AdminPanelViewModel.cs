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
                if (_selectedAbonement != value)
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

        private bool CanAddAbonementCommand(object p) => true;

        private void OnAddAbonementCommand(object p)
        {
            Abonements temp = new Abonements("GYM_3", "18", "BLA", "BLA", 100, 17000);
            AbonementModel abonement = new AbonementModel(temp);
            

            AbonementsList.Add(abonement);



            context.AbonementRepo.AddAbonement(temp);
        }
        #endregion


        #endregion

        public AdminPanelViewModel()
        {
            AddAbonement = new RelayCommand(OnAddAbonementCommand, CanAddAbonementCommand);

            //сразу загрузил даынне
            context = new UnitOfWork();

            //заполнил смотрящего //TODO добавить 
            AbonementsList = new ObservableCollection<AbonementModel>(context.AbonementRepo.GetAllAbonements());

            
            
            

            

        }
    }
}
