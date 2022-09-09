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
    public class CalificacionRepository : ICalificacionRepository
    {
        private readonly ConnectionContext _connectionFactory;

        public CalificacionRepository(ConnectionContext connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public Calificacion RegistrarCalificacion(Calificacion objCalificacion)
        {
            try
            {
                _connectionFactory.Calificaciones.Add(objCalificacion);
                _connectionFactory.SaveChanges();
                return objCalificacion;
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
                return _connectionFactory.Calificaciones.Where(x => x.Usuario_Id.Equals(Usuario_Id)).FirstOrDefault();
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
                Calificacion obj = _connectionFactory.Calificaciones.Where(x => x.Usuario_Id.Equals(objCalificacion.Usuario_Id)).FirstOrDefault();
                obj.Valor_Calificacion = objCalificacion.Valor_Calificacion;
                obj.Clasificacion = objCalificacion.Clasificacion;
                _connectionFactory.SaveChanges();
                return true;
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
                var calificaciones = (from c in _connectionFactory.Calificaciones
                              join u in _connectionFactory.Usuarios
                              on c.Usuario_Id equals u.Usuario_Id
                              where u.Perfil_Id != 1
                              select c).ToList();

                return calificaciones.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
