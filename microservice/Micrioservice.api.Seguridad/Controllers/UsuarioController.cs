using MediatR;
using Microservice.api.Seguridad.Core.Application;
using Microservice.api.Seguridad.Core.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Microservice.api.Seguridad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<UsuarioDTO>> Registrar(Register.UsuarioRegisterCommand parametros)
        {
            return await _mediator.Send(parametros);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UsuarioDTO>> Login(Login.UsuarioLoginCommand parametros)
        {
            return await _mediator.Send(parametros);
        }

        [HttpGet]
        public async Task<ActionResult<UsuarioDTO>> GET()
        {
            return await _mediator.Send(new UsuarioActual.UsuarioActualCommand());
        }
    }
}
