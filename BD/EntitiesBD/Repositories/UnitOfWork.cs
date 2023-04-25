using FitnessCenter.BD.Repositories.EntitiesBD;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter.BD.EntitiesBD.Repositories
{
    class UnitOfWork : IDisposable
    {
        private BDContext context = new BDContext();
        private bool disposed = false;

        private AbonementRepository abonementRepo;
        


        public AbonementRepository AbonementRepo
        {
            get
            {
                if (abonementRepo == null)
                    abonementRepo = new AbonementRepository();
                return abonementRepo;
            }
        }


        




        public void Save() => context.SaveChanges();


        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    context.Dispose();
                this.disposed = true;
            }
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

