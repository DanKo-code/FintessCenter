using FitnessCenter.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter.BD.EntitiesBD
{
    public class Clients : ObservableObject
    {
        private Guid _id;
        private string _name;
        private string _surname;
        private string _login;
        private string _email;
        private string _phone;
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
        public string SurName
        {
            get => _surname;

            set
            {
                _surname = value;
                OnPropertyChanged("SurName");
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
        public string Phone
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

        public virtual ICollection<Orders> Orders { get; set; }

        //public Clients() { }

        //public Clients(string name, string surname, string login, string email, string phone, string password)
        //{
        //    this.Name = name;
        //    this.SurName = surname;
        //    this.Login = login;
        //    this.Email = email;
        //    this.Phone = phone;
        //    this.Password = password;
        //}

        public bool ClientEquals(Clients obj)
        {
            if (
                Id == obj.Id &&
                Name == obj.Name &&
            SurName == obj.SurName &&
            Login == obj.Login &&
            Email == obj.Email &&
            Phone == obj.Phone &&
            Password == obj.Password 
                )
            {
                return true;
            }

            return false;
        }

        public void ResetData(Clients some)
        {
            Id = some.Id;
            Name = some.Name;
            SurName = some.SurName;
            Login = some.Login;
            Email = some.Email;
            Phone = some.Phone;
            Password = some.Password;
        }
    }
}

