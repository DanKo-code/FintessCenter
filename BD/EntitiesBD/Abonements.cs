using FitnessCenter.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter.BD.EntitiesBD
{
    public class Abonements : ObservableObject
    {
        private Guid _id;
        private string _title;
        private int _age;
        private string _validity;
        private string _visitingTime;
        private int _amount;
        private int _price;
        private string _photo;


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
        public int Age 
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

        public string Photo 
        {
            get => _photo;

            set
            {
                _photo = value;
                OnPropertyChanged("Photo");
            }
        }

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

        public Abonements() 
        {
            Id = Guid.NewGuid();
            Title = "";
            Age = 0;
            Validity = "";
            VisitingTime = "";
            Amount = 0;

            Price = 0;
            Photo = "";
        }

        public Abonements(string title, int age, string validity, string visitingTime, int amount, int price, string photo)
        {
            Id = Guid.NewGuid();
            Title = title;
            Age = age;
            Validity = validity;
            VisitingTime = visitingTime;
            Amount = amount;

            Price = price;
            Photo = photo;
        }


    }
}
