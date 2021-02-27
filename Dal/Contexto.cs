using PrimeraPruebaTarea5.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PrimeraPruebaTarea5.Dal
{
    public class Contexto : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Permisos> Permisos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = DATA\GestionDatos.Db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Permisos>().HasData(
                new Permisos() { IdPermiso = 1, NombrePermiso = "Descuenta"},
                new Permisos() { IdPermiso = 2, NombrePermiso = "Vende" },
                new Permisos() { IdPermiso = 3, NombrePermiso = "Cobra" }
            );
        }
    }
}
