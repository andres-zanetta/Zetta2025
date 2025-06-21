using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zetta.BD.DATA.ENTITY;

namespace Zetta.BD.DATA
{
    public class Context : DbContext
    {
        public DbSet <Presupuesto> Presupuestos{ get; set; }
        public DbSet<ItemPresupuesto> ItemPresupuestos { get; set; }
        public DbSet<PresItemDetalle> PresItemDetalles { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Obra> Obras { get; set; }

        public Context(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Presupuesto>()
                .Property(p => p.Total)
                .HasPrecision(18, 2); // 18 dígitos en total, 2 decimales

            // Si querés, podés hacerlo para otras propiedades similares también
        }


    }
}
