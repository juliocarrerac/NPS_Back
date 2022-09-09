using AutoMapper;
using Empresa.Aplicacion.Application.DTO;
using Empresa.Aplicacion.Domain.Entity;

namespace Empresa.Aplicacion.Transversal.Mapper
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
            CreateMap<Calificacion, CalificacionDto>().ReverseMap();

            //CreateMap<Factura, FacturaDto>().ReverseMap().
            //    ForMember(destination => destination.FacturaId, source => source.MapFrom(src => src.FacturaId));
        }
    }
}