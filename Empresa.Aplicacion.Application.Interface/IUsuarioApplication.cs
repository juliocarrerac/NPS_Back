using Empresa.Aplicacion.Application.DTO;
using Empresa.Aplicacion.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Aplicacion.Application.Interface
{
    public interface IUsuarioApplication
    {
        ResponseBase<UsuarioDto> ValidarUsuario(UsuarioDto objUsuario);
    }
}
