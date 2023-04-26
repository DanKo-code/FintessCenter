using FitnessCenter.BD.EntitiesBD;
using FitnessCenter.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FitnessCenter.BD.Repositories.EntitiesBD
{
    public class AbonementRepository
    {
        private BDContext context;

        public AbonementRepository() => context = new BDContext();

        public List<AbonementModel> GetAllAbonements()
        {
            try
            {
                List<AbonementModel> tempList = new List<AbonementModel>();

                foreach (Abonements item in context.Abonements)
                {
                    tempList.Add(new AbonementModel(item));
                }



                return tempList.ToList();
            }
            catch
            {
                return new List<AbonementModel>();
            }
        }

        public bool AddAbonement(Abonements abonement)
        {
            try
            {
                context.Abonements.Add(abonement);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }



        
    }
}
