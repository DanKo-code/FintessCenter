using Microsoft.EntityFrameworkCore;
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
                var res_client = context.Clients.SingleOrDefault(c => c.Id == client.Id);
                var res_abonement = context.Abonements.SingleOrDefault(a => a.Id == abonement.Id);

                context.Orders.Add(new Orders { Id = new Guid(), Abonement = res_abonement, Client = res_client });
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Orders> GetAllOrder()
        {
            try
            {
                return context.Orders.Include(o => o.Client).Include(o => o.Abonement).ToList();
            }
            catch
            {
                return null;
            }
        }
    }
}
