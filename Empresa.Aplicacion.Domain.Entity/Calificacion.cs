using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Aplicacion.Domain.Entity
{
    [Table("Calificacion")]
    public class Calificacion
    {
        [Key]       
        public int Calificacion_Id { get; set; }
        public int Usuario_Id { get; set; }
        public string Clasificacion { get; set; } // Promotor, Neutro, Detractor
        public int? Valor_Calificacion { get; set; }    // rango de 0 a 10
        //public virtual Usuario Usuario { get; set; }
    }
}
