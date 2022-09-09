using Empresa.Aplicacion.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Aplicacion.Infraestructura.Interface
{
    public interface ICalificacionRepository
    {
        Calificacion RegistrarCalificacion(Calificacion objCalificacion);
        bool ActualizarCalificacionPorUsuario(Calificacion objCalificacion);
        Calificacion ObtenerCalificacionPorUsuario(int Usuario_Id);
        List<Calificacion> ListarCalificaciones();
    }
}
