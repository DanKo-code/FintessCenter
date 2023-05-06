using FitnessCenter.BD.EntitiesBD;
using FitnessCenter.BD.EntitiesBD.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter.BD
{
    public class BDContext : DbContext
    {
        private const string Connection =
            @"Data Source=Danila;Initial Catalog=FitessCenter;Integrated Security=True;TrustServerCertificate=Yes;";

        public DbSet<Abonements> Abonements { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Services> Services { get; set; }


        //public BDContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Connection);
        }
    }
}
