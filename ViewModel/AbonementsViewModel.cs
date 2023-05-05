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
        private List<Abonements> _abonementItems = new List<Abonements>();

        public List<Abonements> AbonementItems
        {
            get => _abonementItems;

            set
            {
                if (value != _abonementItems)
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

        #region ReloudAbonementsList
        public ICommand ReloudAbonementsList { get; }

        private bool CanReloudAbonementsListCommand(object p)
        {
            return true;
        }

        private void OnReloudAbonementsListCommand(object p)
        {
            //AbonementItems = Helpers.CurrentClient.abonements;
            AbonementItems = context.AbonementRepo.GetAllAbonements().ToList();
        }
        #endregion

        #endregion

        public AbonementsViewModel()
        {
            context = new UnitOfWork();

            CurrentClient = Helpers.CurrentClient.client;

            AddOrder = new RelayCommand(OnAddOrderCommand, CanAddOrderCommand);

            ReloudAbonementsList = new RelayCommand(OnReloudAbonementsListCommand, CanReloudAbonementsListCommand);

            AbonementItems = Helpers.CurrentClient.abonements;
        }

    }
}
