using FitnessCenter.BD.EntitiesBD;
using FitnessCenter.BD.EntitiesBD.Repositories;
using FitnessCenter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace FitnessCenter.ViewModel
{
    class ProfileViewModel : ObservableObject
    {
        private UnitOfWork context;

        #region Accessors (helpers for ui design)

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

        #region AbonementItems
        private List<Abonements> _abonementItems = new List<Abonements>
        {
            new Abonements(),
            new Abonements(),
            
        };

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

        #endregion

        #region Commands
        #region SaveAllChanges
        public ICommand SaveAllChanges { get; }

        private bool CanSaveAllChangesCommand(object p)
        {
            return true;
        }
        private void OnSaveAllChangesCommand(object p)
        {
            context.ClientRepo.SaveAllChanges(CurrentClient);
            MessageBox.Show("Все удачно сохранено!");
        }
        #endregion
        #endregion

        public ProfileViewModel(Clients client)
        {
            context = new UnitOfWork();

            CurrentClient = client;

            SaveAllChanges = new RelayCommand(OnSaveAllChangesCommand, CanSaveAllChangesCommand);
        }
    }
}
