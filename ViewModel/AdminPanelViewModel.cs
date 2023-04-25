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
        public ObservableCollection<Abonements> AbonementsList { get; set; }

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
        private Abonements _selectedProducts;

        public Abonements SelectedProducts
        {
            get => _selectedProducts;

            set
            {
                if (_selectedProducts != value)
                {
                    _selectedProducts = value;
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
            Abonements abonement = new Abonements();

            AbonementsList.Add(abonement);
            context.AbonementRepo.AddAbonement(abonement);
        }
        #endregion


        #endregion

        public AdminPanelViewModel()
        {
            AddAbonement = new RelayCommand(OnAddAbonementCommand, CanAddAbonementCommand);

            //сразу загрузил даынне
            context = new UnitOfWork();

            //заполнил смотрящего 
            AbonementsList = new ObservableCollection<Abonements>(context.AbonementRepo.GetAllAbonements());

            
            
            

            

        }
    }
}
