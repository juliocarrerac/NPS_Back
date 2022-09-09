using Empresa.Aplicacion.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Aplicacion.Infraestructura.Interface
{
    public interface IUsuarioRepository
    {
        Usuario ValidarUsuario(Usuario objUsuario);
        Usuario ObtenerUsuario(int Usuario_Id);
    }
}
