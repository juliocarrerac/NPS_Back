using Empresa.Aplicacion.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Aplicacion.Domain.Interface
{
    public interface ICalificacionDomain
    {
        Calificacion RegistrarCalificacion(Calificacion objCalificacion);
        Calificacion ObtenerCalificacionPorUsuario(int Usuario_Id);
        bool ActualizarCalificacionPorUsuario(Calificacion objCalificacion);
        List<Calificacion> ListarCalificaciones();
    }
}
