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
    public class CalificacionDomain : ICalificacionDomain
    {
        private readonly ICalificacionRepository _calificacionRepository;

        public CalificacionDomain(ICalificacionRepository calificacionRepository)
        {
            _calificacionRepository = calificacionRepository;
        }

        public Calificacion RegistrarCalificacion(Calificacion objCalificacion)
        {
            try
            {
                if(objCalificacion.Valor_Calificacion < 7)
                {
                    objCalificacion.Clasificacion = "Detractor";
                }else if(objCalificacion.Valor_Calificacion > 6 || objCalificacion.Valor_Calificacion < 9)
                {
                    objCalificacion.Clasificacion = "Neutro";
                }
                else
                {
                    objCalificacion.Clasificacion = "Promotor";
                }
                return _calificacionRepository.RegistrarCalificacion(objCalificacion);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Calificacion ObtenerCalificacionPorUsuario(int Usuario_Id)
        {
            try
            {
                return _calificacionRepository.ObtenerCalificacionPorUsuario(Usuario_Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool ActualizarCalificacionPorUsuario(Calificacion objCalificacion)
        {
            try
            {
                if (objCalificacion.Valor_Calificacion < 7)
                {
                    objCalificacion.Clasificacion = "Detractor";
                }
                else if (objCalificacion.Valor_Calificacion > 6 && objCalificacion.Valor_Calificacion < 9)
                {
                    objCalificacion.Clasificacion = "Neutro";
                }
                else
                {
                    objCalificacion.Clasificacion = "Promotor";
                }
                return _calificacionRepository.ActualizarCalificacionPorUsuario(objCalificacion);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Calificacion> ListarCalificaciones()
        {
            try
            {
                return _calificacionRepository.ListarCalificaciones();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
    }
}
