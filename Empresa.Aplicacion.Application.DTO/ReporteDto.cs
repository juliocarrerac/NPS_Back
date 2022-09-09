using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Aplicacion.Application.DTO
{
    public class ReporteDto
    {
        public string Usuario { get; set; }
        public string Clasificacion { get; set; }
        public int? Valor_Calificacion { get; set; }
        public string Estado { get; set; }
        public decimal NPS { get; set; }
        public decimal CantidadPromotores { get; set; }
        public decimal CantidadDetractores { get; set; }
        public decimal CantidadEncuestados { get; set; }
    }
}
