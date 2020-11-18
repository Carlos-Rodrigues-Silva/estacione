using Core.Entidades;
using Core.Entidades.OrdemAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Infraestrutura.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Estacionamento> Estacionamentos { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }

        public DbSet<Logradouro> Logradouros { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Ordem> Ordens { get; set; }

        public DbSet<VagaAlugada> VagaAlugadas { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
