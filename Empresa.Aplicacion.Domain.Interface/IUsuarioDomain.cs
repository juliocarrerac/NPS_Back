using Empresa.Aplicacion.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Aplicacion.Domain.Interface
{
    public interface IUsuarioDomain
    {
        public Usuario ValidarUsuario(Usuario objUsuario);
        public Usuario ObtenerUsuario(int Usuario_Id);
    }
}
