using Empresa.Aplicacion.Domain.Entity;
using Empresa.Aplicacion.Domain.Interface;
using Empresa.Aplicacion.Infraestructura.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Aplicacion.Domain.Core
{
    public class UsuarioDomain : IUsuarioDomain
    {
        private readonly IUsuarioRepository _usuarioRepository;
        //private readonly ICalificacionRepository _calificacionRepository;

        public UsuarioDomain(IUsuarioRepository usuarioRepository) //ICalificacionRepository calificacionRepository
        {
            _usuarioRepository = usuarioRepository;
            //_calificacionRepository = calificacionRepository;
        }

        public Usuario ValidarUsuario(Usuario objUsuario)
        {
            try
            {
                //Calificacion objCalificacion = new Calificacion();
                //Usuario objUser  = _usuarioRepository.ValidarUsuario(objUsuario);
                //if (objUser.Usuario_Id > 0)
                //{
                //    objCalificacion = _calificacionRepository.ObtenerCalificacionPorUsuario(objUsuario.Usuario_Id);
                //}
                //if(objCalificacion.Valor_Calificacion != null)
                //{
                //    objUser.Valor_Calificacion = objCalificacion.Valor_Calificacion;
                //}               
                //return objUser;

                return _usuarioRepository.ValidarUsuario(objUsuario);

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
                return _usuarioRepository.ObtenerUsuario(Usuario_Id);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
    }
}
