using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Aplicacion.Application.DTO
{
    public class CalificacionDto
    {
        public int Calificacion_Id { get; set; }
        public int Usuario_Id { get; set; }
        public string Clasificacion { get; set; } // Promotor, Neutro, Detractor
        public int? Valor_Calificacion { get; set; }    // rango de 0 a 10
    }
}
