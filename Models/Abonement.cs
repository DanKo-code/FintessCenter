using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter.Models
{
    public class Abonement
    {
        public string Name { get; set; }    
        public int Age { get; set; }    
        public int Validity { get; set; }    
        public int VisitingTime { get; set; }    
        
        //TODO добавить что включает абонемент

        public int Amount { get; set; }

        public int Price{ get; set; }
        


    }
}
