using AutoMapper;
using FluentValidation;
using MediatR;
using Micrioservice.api.Seguridad.Core.Entities;
using Micrioservice.api.Seguridad.Core.Persistence;
using Microservice.api.Seguridad.Core.Dto;
using Microservice.api.Seguridad.Core.JWTLogic;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microservice.api.Seguridad.Core.Application
{
    public class Login
    {
        public class UsuarioLoginCommand: IRequest<UsuarioDTO>
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class UsuarioLoginValidation: AbstractValidator<UsuarioLoginCommand>
        {
            public UsuarioLoginValidation()
            {
                RuleFor(x => x.Email).NotEmpty();
                RuleFor(x => x.Password).NotEmpty();
            }
        }

        public class UsuarioLoginHandler : IRequestHandler<UsuarioLoginCommand, UsuarioDTO>
        {
            private readonly SeguridadContexto _context;
            private readonly UserManager<Usuario> _userManager;
            private readonly IMapper _mapper;
            private readonly IJWTGenerator _jwtGenerator;
            private readonly SignInManager<Usuario> _signInManager;
            public UsuarioLoginHandler(SeguridadContexto contexto, UserManager<Usuario> userManager, IMapper mapper, IJWTGenerator jwtGenerator, SignInManager<Usuario> signInManager)
            {
                _context = contexto;
                _userManager = userManager;
                _mapper = mapper;
                _jwtGenerator = jwtGenerator;
                _signInManager = signInManager;
            }
            public async Task<UsuarioDTO> Handle(UsuarioLoginCommand request, CancellationToken cancellationToken)
            {
                var usuario = await _userManager.FindByEmailAsync(request.Email);
                if (usuario == null)
                {
                    throw new Exception("El usuario no existe");
                }
                var resultado = await _signInManager.CheckPasswordSignInAsync(usuario, request.Password, false);
                if (resultado.Succeeded)
                {
                    var usuarioDTO = _mapper.Map<Usuario, UsuarioDTO>(usuario);
                    usuarioDTO.Token = _jwtGenerator.CreateToken(usuario);
                    return usuarioDTO;
                }
                throw new Exception("Login Incorrecto");
            }
        }
    }
}
