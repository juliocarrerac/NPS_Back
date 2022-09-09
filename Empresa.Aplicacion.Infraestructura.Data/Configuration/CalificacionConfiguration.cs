using Empresa.Aplicacion.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Aplicacion.Infraestructura.Data.Configuration
{
    public class CalificacionConfiguration
    {
        public CalificacionConfiguration(EntityTypeBuilder<Calificacion> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.Calificacion_Id);
            this.SeedCalificacion(entityBuilder);
        }

        private void SeedCalificacion(EntityTypeBuilder<Calificacion> entityBuilder)
        {
            Calificacion calificacion = new Calificacion()
            {
                Calificacion_Id = 1,
                Usuario_Id = 2,
                Clasificacion = "",
                Valor_Calificacion = null
            };
            entityBuilder.HasData(calificacion);

            calificacion = new Calificacion()
            {
                Calificacion_Id = 2,
                Usuario_Id = 3,
                Clasificacion = "",
                Valor_Calificacion = null
            };
            entityBuilder.HasData(calificacion);

            calificacion = new Calificacion()
            {
                Calificacion_Id = 3,
                Usuario_Id = 4,
                Clasificacion = "",
                Valor_Calificacion = null
            };
            entityBuilder.HasData(calificacion);

            calificacion = new Calificacion()
            {
                Calificacion_Id = 4,
                Usuario_Id = 5,
                Clasificacion = "",
                Valor_Calificacion = null
            };
            entityBuilder.HasData(calificacion);

            calificacion = new Calificacion()
            {
                Calificacion_Id = 5,
                Usuario_Id = 6,
                Clasificacion = "",
                Valor_Calificacion = null
            };
            entityBuilder.HasData(calificacion);
        }
    }
}
