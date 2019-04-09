using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MultasB.Models
{
    public class MultasDB : DbContext
    {
        public MultasDB() : base("MultasDBConnectionString") { }

        // Definir as tabelas da DB

        public DbSet<Condutores> Condutores { get; set; }
        public DbSet<Agentes> Agentes { get; set; }
        public DbSet<Viaturas> Viaturas { get; set; }
        public DbSet<Multas> Multas { get; set; }


        // Método a ser executado no inicio da criação do modelo
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Eliminar a convenção de atribuir automaticamente o 'onDeleteCascade' nas FKs
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }



    }
}