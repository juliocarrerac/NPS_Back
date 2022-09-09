using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Aplicacion.Domain.Entity
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int Usuario_Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        //public virtual Calificacion Calificacion { get; set; }

        [ForeignKey("Perfil_Id")]
        [InverseProperty("lst_Usuarios")]
        public virtual Perfil Perfil { get; set; }
        public int Perfil_Id { get; set; }
    }
}
