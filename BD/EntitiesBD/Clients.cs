using FitnessCenter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter.BD.EntitiesBD
{
    public class Clients : ObservableObject
    {
        private Guid _id;
        private string _name;
        private int _surname;
        private string _login;
        private string _email;
        private int _phone;
        private int _role;
        private string _password;

        public Guid Id
        {
            get => _id;

            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }
        public string Name
        {
            get => _name;

            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public int Surname
        {
            get => _surname;

            set
            {
                _surname = value;
                OnPropertyChanged("Surname");
            }
        }
        public string Login
        {
            get => _login;

            set
            {
                _login = value;
                OnPropertyChanged("Login");
            }
        }
        public string Email
        {
            get => _email;

            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }
        public int Phone
        {
            get => _phone;

            set
            {
                _phone = value;
                OnPropertyChanged("Phone");
            }
        }

        public int Role
        {
            get => _role;

            set
            {
                _role = value;
                OnPropertyChanged("Role");
            }
        }

        public string Password
        {
            get => _password;

            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        public ICollection<Orders> Orders { get; set; }

        public Clients() => Orders = new List<Orders>();
    }
}

