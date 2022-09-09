using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Aplicacion.Application.DTO
{
    public class UsuarioDto
    {
        public int Usuario_Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public int Perfil_Id { get; set; }
        //[NotMapped]
        //public CalificacionDto Calificacion { get; set; }
    }
}
