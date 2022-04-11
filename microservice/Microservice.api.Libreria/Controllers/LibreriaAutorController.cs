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
    public class LibreriaAutorController : ControllerBase
    {
        private readonly IMongoRepository<AutorEntity> _autorGRepository;

        public LibreriaAutorController( IMongoRepository<AutorEntity> autorGRepository)
        {
            _autorGRepository = autorGRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AutorEntity>>> Get() {
            return Ok(await _autorGRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AutorEntity>> GetById(string id){
            var autor = await _autorGRepository.GetById(id);
            return Ok(autor);
        }

        [HttpPost]
        public async Task Post(AutorEntity autor)
        {
            await _autorGRepository.InsertDocument(autor);
        }

        [HttpPut("{id}")]
        public async Task Put(string Id, AutorEntity autor)
        {
            autor.Id = Id;
            await _autorGRepository.UpdateDocument(autor);
        }

        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await _autorGRepository.DeleteById(id);
        }

        [HttpPost("pagination")]
        public async Task<ActionResult<PaginationEntity<AutorEntity>>> PostPagination(PaginationEntity<AutorEntity> pagination)
        {
            var resultados = await _autorGRepository.PaginationByFilter(pagination);
            return Ok(resultados);
        }
    }
}
