using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter.BD.EntitiesBD.Repositories
{
    public class ServiceRepository
    {
        private BDContext context;
        public ServiceRepository(BDContext context) => this.context = context;

        public bool AddService(Services Service)
        {
            try
            {
                context.Services.Add(Service);

                context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Services> GetAllServices()
        {
            try
            {
                return context.Services.ToList();
            }
            catch
            {
                return null;
            }
        }
    }
}
