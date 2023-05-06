using FitnessCenter.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter.BD.EntitiesBD
{
    public class Orders : ObservableObject
    {
        public Guid Id { get; set; }

        [ForeignKey("Abonements")]
        public Guid? AbonementsId { get; set; }

        [ForeignKey("Clients")]
        public Guid? ClientsId { get; set; }

        private int _status;
        public int Status 
        {
            get => _status;

            set
            {
                _status = value;
                OnPropertyChanged("Status");
            }
        }

        public virtual Abonements Abonement { get; set; }
        public virtual Clients Client { get; set; }

        public override string ToString()
        {
            return "";
        }
    }
}
