using Microservice.api.Libreria.Core.Entities;
using Microservice.api.Libreria.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservice.api.Libreria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibreriaServicioController : ControllerBase
    {
        private readonly IAutorRepository _autorRepository;
        private readonly IMongoRepository<AutorEntity> _mongoRepository;
        private readonly IMongoRepository<EmpleadoEntity> _empleadoGRepository;
        public LibreriaServicioController(IAutorRepository autorRepository, IMongoRepository<AutorEntity> mongoRepository, IMongoRepository<EmpleadoEntity> empleadoGRepository)
        {
            _autorRepository = autorRepository;
            _mongoRepository = mongoRepository;
            _empleadoGRepository = empleadoGRepository;
        }

        [HttpGet("autores")]
        public async Task<ActionResult<IEnumerable<Autor>>> GetAutores()
        {
            var autores = await _autorRepository.GetAutores();
            return Ok(autores);
        }

        [HttpGet("autorGenerico")]
        public async Task<ActionResult<IEnumerable<AutorEntity>>> GetAutorGenerico()
        {
            var autores = await _mongoRepository.GetAll();
            return Ok(autores);
        }

        [HttpGet("empleadoGenerico")]
        public async Task<ActionResult<IEnumerable<EmpleadoEntity>>> GetEmpleadoGenerico()
        {
            var empleados = await _empleadoGRepository.GetAll();
            return Ok(empleados);
        }
    }
}
