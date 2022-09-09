using System;
using System.Collections.Generic;
using System.Text;
using Empresa.Aplicacion.Transversal.Common;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using Empresa.Aplicacion.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Empresa.Aplicacion.Infraestructura.Data.Configuration;

namespace Empresa.Aplicacion.Infraestructura.Data
{
    public class ConnectionContext : DbContext
    {
        public ConnectionContext(DbContextOptions<ConnectionContext> options) : base(options)
        {
            
        }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Perfil> Perfiles { get; set; }
        public virtual DbSet<Calificacion> Calificaciones { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //this.Configuration.LazyLoadingEnabled = false;
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();


            //modelBuilder.Entity<Usuario>().HasOne(e => e.Calificacion);

            ModelConfig(modelBuilder);
        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new UsuarioConfiguration(modelBuilder.Entity<Usuario>());
            new CalificacionConfiguration(modelBuilder.Entity<Calificacion>());
            new PerfilConfiguration(modelBuilder.Entity<Perfil>());
            
        }
    }
}
