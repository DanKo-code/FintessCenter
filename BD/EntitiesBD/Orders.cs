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
        //public Guid Id_User { get; set; }
        //public Guid Id_Abonement { get; set; }

        [NotMapped]
        public Clients client { get; set; }

        [NotMapped]
        public Abonements abonement { get; set; }
    }
}
