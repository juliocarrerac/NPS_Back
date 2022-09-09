using Empresa.Aplicacion.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Aplicacion.Infraestructura.Data.Configuration
{
    public class PerfilConfiguration
    {
        public PerfilConfiguration(EntityTypeBuilder<Perfil> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.Perfil_Id);
            this.SeedPerfil(entityBuilder);
        }

        private void SeedPerfil(EntityTypeBuilder<Perfil> entityBuilder)
        {
            Perfil perfil = new Perfil()
            {
                Perfil_Id = 1,
                Descripcion = "Administrador"
            };
            entityBuilder.HasData(perfil);

            perfil = new Perfil()
            {
                Perfil_Id = 2,
                Descripcion = "Votante"
            };
            entityBuilder.HasData(perfil);
        }
    }
}
