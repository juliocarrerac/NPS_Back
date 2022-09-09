using Empresa.Aplicacion.Application.DTO;
using Empresa.Aplicacion.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Aplicacion.Application.Interface
{
    public interface ICalificacionApplication
    {
        ResponseBase<CalificacionDto> RegistrarCalificacion(CalificacionDto objCalificacion);
        ResponseBase<CalificacionDto> ObtenerCalificacionPorUsuario(int Usuario_Id);
        ResponseBase<bool> ActualizarCalificacionPorUsuario(CalificacionDto objCalificacion);
        List<ReporteDto> ListarCalificaciones();
    }
}
