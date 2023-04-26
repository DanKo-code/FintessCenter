using FitnessCenter.BD.EntitiesBD;
using FitnessCenter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter.Models
{
    internal class AbonementModel : ObservableObject
    {
        private string _title;
        private string _validity;
        private string _visitingTime;
        private int _amount;
        private int _price;

        public AbonementModel(Abonements abonements)
        {
            _title = abonements.Title;
            _validity = abonements.Validity;
            _visitingTime = abonements.VisitingTime;
            _amount = abonements.Amount;
            _price = abonements.Price;
        }

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        public string Validity
        {
            get { return _validity; }
            set
            {
                _validity = value;
                OnPropertyChanged("Category");
            }
        }

        public string VisitingTime
        {
            get { return _visitingTime; }
            set
            {
                _visitingTime = value;
                OnPropertyChanged("VisitingTime");
            }
        }

        public int Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                OnPropertyChanged("Amount");
            }
        }

    }
}
