using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter.BD.EntitiesBD.Repositories
{
    class OrderRepository
    {
        private BDContext context;

        public OrderRepository() => context = new BDContext();

        public bool AddOrder(Clients client, Abonements abonement)
        {
            try
            {
                context.Orders.Add(new Orders(client, abonement));
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
