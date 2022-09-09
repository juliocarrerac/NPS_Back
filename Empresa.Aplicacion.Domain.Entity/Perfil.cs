using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Aplicacion.Domain.Entity
{
    [Table("Perfil")]
    public class Perfil
    {
        [Key]
        public int Perfil_Id { get; set; }
        public string Descripcion { get; set; } //Administrador y Votante
        public virtual ICollection<Usuario> lst_Usuarios { get; set; }
    }
}
