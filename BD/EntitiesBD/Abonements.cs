using FitnessCenter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter.BD.EntitiesBD
{
    public class Abonements : ObservableObject
    {
        private Guid _id;
        private string _title;
        private string _age;
        private string _validity;
        private string _visitingTime;
        private int _amount;
        private int _price;


        public Guid Id 
        {
            get => _id; 

            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }
        public string Title
        {
            get => _title;

            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }
        public string Age 
        {
            get => _age;

            set
            {
                _age = value;
                OnPropertyChanged("Age");
            }
        }
        public string Validity 
        {
            get => _validity;

            set
            {
                _validity = value;
                OnPropertyChanged("Validity");
            }
        }
        public string VisitingTime 
        {
            get => _visitingTime;

            set
            {
                _visitingTime = value;
                OnPropertyChanged("VisitingTime");
            }
        }
        public int Amount 
        {
            get => _amount;

            set
            {
                _amount = value;
                OnPropertyChanged("Amount");
            }
        }
        //public string Photo { get; set; }
        public int Price 
        {
            get => _price;

            set
            {
                _price = value;
                OnPropertyChanged("Price");
            }
        }

        public ICollection<Orders> Orders { get; set; }

        //public Abonements() { }

        public Abonements(string title, string age, string validity, string visitingTime, int amount, int price)
        {
            Id = Guid.NewGuid();
            Title = title;
            Age = age;
            Validity = validity;
            VisitingTime = visitingTime;
            Amount = amount;

            Price = price;
        }


    }
}
