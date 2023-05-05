using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter.BD.EntitiesBD.Repositories
{
    public class ClientRepository
    {
        private BDContext context;

        public ClientRepository(BDContext context) => this.context = context;

        public bool AddClient(Clients client)
        {
            try
            {
                context.Clients.Add(client);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CheckLogin(string clientLogin)
        {
            try
            {
                Clients temp = context.Clients.FirstOrDefault(x => x.Login == clientLogin);

                if (temp != null) 
                    return true;

                return false;
            }
            catch
            {
                return false;
            }
        }

        public Clients CheckPassword(string clientLogin, string clientPassword)
        {
            try
            {
                Clients temp = context.Clients.FirstOrDefault(x => x.Login == clientLogin);

                if (temp.Password == clientPassword) 
                    return temp;

                return null;
            }
            catch
            {
                return null;
            }
        }

        public bool SaveAllChanges(Clients client)
        {
            try
            {
                Clients temp = context.Clients.FirstOrDefault(x => x.Id == client.Id);

                if (!temp.ClientEquals(client))
                {
                    temp.ResetData(client);
                }

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
