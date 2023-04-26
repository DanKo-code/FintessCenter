using FitnessCenter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter.BD.EntitiesBD
{
    public class Abonements
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Age { get; set; }
        public string Validity { get; set; }
        public string VisitingTime { get; set; }
        public int Amount { get; set; }
        //public string Photo { get; set; }
        public int Price { get; set; }

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

        //public override string ToString() => $"{Title} — {Director} ({Genre}) {Duration} мин; {Rating}";
    }
}
