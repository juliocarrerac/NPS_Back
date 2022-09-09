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
    public class UsuarioApplication : IUsuarioApplication
    {
        private readonly IUsuarioDomain _usuarioDomain;
        private readonly ICalificacionDomain _calificacionDomain;
        private readonly IMapper _mapper;

        public UsuarioApplication(IUsuarioDomain usuarioDomain, ICalificacionDomain calificacionDomain, IMapper mapper)
        {
            _usuarioDomain = usuarioDomain;
            _calificacionDomain = calificacionDomain;
            _mapper = mapper;
        }

        public ResponseBase<UsuarioDto> ValidarUsuario(UsuarioDto objUsuarioDto)
        {
            var response = new ResponseBase<UsuarioDto>();
            try
            {
                var usuario = _mapper.Map<Usuario>(objUsuarioDto);
                Usuario obj = _usuarioDomain.ValidarUsuario(usuario);
                if(obj != null)
                {
                    response.Data = _mapper.Map<UsuarioDto>(obj);

                    response.Login = response.Data.Login;
                    response.Usuario_Id = response.Data.Usuario_Id;
                    response.Token = response.Data.Token;
                    response.Perfil_Id = response.Data.Perfil_Id;
                }               
                if (response.Data != null)
                {
                    if(response.Perfil_Id != 1)
                    {
                        response.Valor_Calificacion = _calificacionDomain.ObtenerCalificacionPorUsuario(response.Data.Usuario_Id).Valor_Calificacion;
                    }
                    
                    response.IsSuccess = true;
                    response.Message = "Usario validado correctamente";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
