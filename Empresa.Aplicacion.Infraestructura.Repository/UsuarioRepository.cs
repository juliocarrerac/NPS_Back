using Empresa.Aplicacion.Domain.Entity;
using Empresa.Aplicacion.Infraestructura.Data;
using Empresa.Aplicacion.Infraestructura.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Aplicacion.Infraestructura.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ConnectionContext _connectionFactory;

        public UsuarioRepository(ConnectionContext connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public Usuario ValidarUsuario(Usuario objUsuario)
        {
            try
            {
                return _connectionFactory.Usuarios.Where(x => x.Login.Equals(objUsuario.Login) && x.Password.Equals(objUsuario.Password)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Usuario ObtenerUsuario(int Usuario_Id)
        {
            try
            {
                return _connectionFactory.Usuarios.Where(x => x.Usuario_Id.Equals(Usuario_Id)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
    }
}
