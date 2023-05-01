using FitnessCenter.BD.EntitiesBD;
using FitnessCenter.BD.EntitiesBD.Repositories;
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
    class AbonementsViewModel : ObservableObject
    {
        private UnitOfWork context;

        #region Accessors (helpers for ui design)

        #region AbonementItems
        private List<Abonements> _abonementItems;

        public List<Abonements> AbonementItems
        {
            get => _abonementItems;

            set
            {
                if (_abonementItems != value)
                {
                    _abonementItems = value;
                    OnPropertyChanged(nameof(AbonementItems));
                }
            }
        }
        #endregion

        #region CurrentClient
        private Clients _client;

        public Clients CurrentClient
        {
            get => _client;

            set
            {
                if (_client != value)
                {
                    _client = value;
                    OnPropertyChanged(nameof(CurrentClient));
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

        #endregion

        #region Commands

        #region AddOrder
        public ICommand AddOrder { get; }

        private bool CanAddOrderCommand(object p)
        {
            return SelectedProducts != null;
        }

        private void OnAddOrderCommand(object p)
        {
            context.OrderRepo.AddOrder(CurrentClient, SelectedProducts);
            MessageBox.Show("Заказ успешно отправлен на подтверждение!");
        }
        #endregion

        #endregion

        public AbonementsViewModel()
        {
            context = new UnitOfWork();

            CurrentClient = Helpers.CurrentClient.client;

            AddOrder = new RelayCommand(OnAddOrderCommand, CanAddOrderCommand);

            
            AbonementItems = Helpers.CurrentClient.abonements;
        }

    }
}
