using FitnessCenter.BD.EntitiesBD;
using FitnessCenter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter.Models
{
    public class AbonementModel : ObservableObject
    {
        private string _title;
        private string _age;
        private string _validity;
        private string _visitingTime;
        private int _amount;
        private int _price;

        public override bool Equals(object? obj)
        {
            if (obj is AbonementModel temp)
            {
                if (temp.Title == this.Title &&
                temp.Age == this.Age &&
                temp.Validity == this.Validity &&
                temp.VisitingTime == this.VisitingTime &&
                temp.Amount == this.Amount &&
                temp.Price == this.Price)
                    return true;

                return false;
            }

            return false;
        }

        public AbonementModel(Abonements abonements)
        {
            _title = abonements.Title;
            _age = abonements.Age;
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

        public string Age
        {
            get { return _age; }
            set
            {
                _age = value;
                OnPropertyChanged("Age");
            }
        }

        public string Validity
        {
            get { return _validity; }
            set
            {
                _validity = value;
                OnPropertyChanged("Validity");
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

        public int Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged("Price");
            }
        }

    }
}
