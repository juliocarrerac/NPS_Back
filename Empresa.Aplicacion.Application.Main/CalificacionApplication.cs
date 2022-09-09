using AutoMapper;
using Empresa.Aplicacion.Application.DTO;
using Empresa.Aplicacion.Application.Interface;
using Empresa.Aplicacion.Domain.Entity;
using Empresa.Aplicacion.Domain.Interface;
using Empresa.Aplicacion.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Aplicacion.Application.Main
{
    public class CalificacionApplication : ICalificacionApplication
    {
        private readonly ICalificacionDomain _calificacionDomain;
        private readonly IUsuarioDomain _usuarioDomain;
        private readonly IMapper _mapper;

        public CalificacionApplication(ICalificacionDomain calificacionDomain, IUsuarioDomain usuarioDomain, IMapper mapper)
        {
            _calificacionDomain = calificacionDomain;
            _usuarioDomain = usuarioDomain;
            _mapper = mapper;
        }

        public ResponseBase<CalificacionDto> RegistrarCalificacion(CalificacionDto objCalificacionDto)
        {
            var response = new ResponseBase<CalificacionDto>();
            try
            {
                var calificacion = _mapper.Map<Calificacion>(objCalificacionDto);
                Calificacion obj = _calificacionDomain.RegistrarCalificacion(calificacion);
                response.Data = _mapper.Map<CalificacionDto>(obj);

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Calificación registrada correctamente";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public ResponseBase<CalificacionDto> ObtenerCalificacionPorUsuario(int Usuario_Id)
        {
            var response = new ResponseBase<CalificacionDto>();
            try
            {
                Calificacion obj = _calificacionDomain.ObtenerCalificacionPorUsuario(Usuario_Id);
                response.Data = _mapper.Map<CalificacionDto>(obj);

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public ResponseBase<bool> ActualizarCalificacionPorUsuario(CalificacionDto objCalificacionDto)
        {
            var response = new ResponseBase<bool>();
            try
            {
                var calificacion = _mapper.Map<Calificacion>(objCalificacionDto);
                bool exito = _calificacionDomain.ActualizarCalificacionPorUsuario(calificacion);
                if (exito)
                {
                    response.IsSuccess = true;
                    response.Message = "Se ha registrado su calificación.";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public List<ReporteDto> ListarCalificaciones()
        {
            var response = new List<ReporteDto>();
            ReporteDto reporteDto;
            try
            {
                List<Calificacion> lstAuxiliar = _calificacionDomain.ListarCalificaciones();
                decimal cantidadPromotor = 0;
                decimal cantidadDetractor = 0;
                decimal cantidadEncuestados = 0;
                decimal NPS = 0;
                foreach (var item in lstAuxiliar)
                {
                    reporteDto = new ReporteDto();
                    reporteDto.Valor_Calificacion = item.Valor_Calificacion;
                    reporteDto.Clasificacion = item.Clasificacion;
                    reporteDto.Usuario = _usuarioDomain.ObtenerUsuario(item.Usuario_Id).Login;
                    reporteDto.Estado = item.Valor_Calificacion == null ? "No ha votado" : "Ya voto";
                    
                    if (reporteDto.Estado == "Ya voto" && reporteDto.Clasificacion == "Detractor")
                    {
                        cantidadDetractor += 1;
                    }
                    if (reporteDto.Estado == "Ya voto" && reporteDto.Clasificacion == "Promotor")
                    {
                        cantidadPromotor += 1;
                    }
                    if (reporteDto.Estado == "Ya voto")
                    {
                        cantidadEncuestados += 1;
                    }
                    
                    response.Add(reporteDto);
                }
                NPS = (cantidadPromotor - cantidadDetractor) / cantidadEncuestados * 100;
                foreach (var item in response)
                {
                    item.NPS = decimal.Round(NPS, 2); ;
                    item.CantidadEncuestados = cantidadEncuestados;
                    item.CantidadPromotores = cantidadPromotor;
                    item.CantidadDetractores = cantidadDetractor;
                }

            }
            catch (Exception ex)
            {
                
            }
            return response;
        }
        
    }
}
