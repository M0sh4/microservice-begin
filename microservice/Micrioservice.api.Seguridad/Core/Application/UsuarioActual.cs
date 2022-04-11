using AutoMapper;
using MediatR;
using Micrioservice.api.Seguridad.Core.Entities;
using Microservice.api.Seguridad.Core.Dto;
using Microservice.api.Seguridad.Core.JWTLogic;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microservice.api.Seguridad.Core.Application
{
    public class UsuarioActual
    {
        public class UsuarioActualCommand: IRequest<UsuarioDTO>
        {

        }

        public class UsuarioActualHandler : IRequestHandler<UsuarioActualCommand, UsuarioDTO>
        {
            private readonly UserManager<Usuario> _userManager;
            private readonly IUsuarioSesion _usuarioSesion;
            private readonly IJWTGenerator _jwtGenerator;
            private readonly IMapper _mapper;

            public UsuarioActualHandler(UserManager<Usuario> userManager, IUsuarioSesion usuarioSesion, IJWTGenerator jwtGenerator, IMapper mapper)
            {
                _userManager = userManager;
                _usuarioSesion = usuarioSesion;
                _jwtGenerator = jwtGenerator;
                _mapper = mapper;
            }
            public async Task<UsuarioDTO> Handle(UsuarioActualCommand request, CancellationToken cancellationToken)
            {
                var usuario = await _userManager.FindByNameAsync(_usuarioSesion.GetUsuarioSesion());
                if (usuario != null)
                {
                    var usuarioDTO = _mapper.Map<Usuario,UsuarioDTO>(usuario);
                    usuarioDTO.Token = _jwtGenerator.CreateToken(usuario);
                    return usuarioDTO;
                }
                throw new Exception("No se encontró el usuario");
            }
        }
    }
}
