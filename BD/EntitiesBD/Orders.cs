using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter.BD.EntitiesBD
{
    public class Orders
    {
        public Guid Id { get; set; }
       
        public Guid AbonementsId { get; set; }
        public Guid ClientsId { get; set; }

        public Abonements Abonement { get; set; }
        public Clients Client { get; set; }

        public Orders() { }

        public Orders(Clients client, Abonements abonement)
        {
            Id = new Guid();

            ClientsId = client.ClientsId;
            AbonementsId = abonement.AbonementsId;
            
        }
    }
}
