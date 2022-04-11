using AutoMapper;
using Micrioservice.api.Seguridad.Core.Entities;
using Microservice.api.Seguridad.Core.Dto;

namespace Microservice.api.Seguridad.Core.DTO
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Usuario, UsuarioDTO>();
        }
    }
}
