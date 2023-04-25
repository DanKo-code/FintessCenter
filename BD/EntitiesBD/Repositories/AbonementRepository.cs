using FitnessCenter.BD.EntitiesBD;
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

        public List<Abonements> GetAllAbonements()
        {
            try
            {

                return context.Abonements.ToList();
            }
            catch
            {
                return new List<Abonements>();
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
