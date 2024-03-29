﻿using Microservice.api.Libreria.Core.Entities;
using Microservice.api.Libreria.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservice.api.Libreria.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly IMongoRepository<LibroEntity> _libroRepository;

        public LibroController(IMongoRepository<LibroEntity> libroRepository)
        {
            _libroRepository = libroRepository;
        }

        [HttpPost]
        public async Task PostSave(LibroEntity libro)
        {
            await _libroRepository.InsertDocument(libro);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LibroEntity>>> Get()
        {
            return Ok(await _libroRepository.GetAll());
        }

        [HttpPost]
        public async Task<ActionResult<PaginationEntity<LibroEntity>>> PostPagination(PaginationEntity<LibroEntity> pagination)
        {
            var resultados = await _libroRepository.PaginationByFilter(pagination);
            return Ok(resultados);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<LibroEntity>> GetById(string id)
        {
            var libro = await _libroRepository.GetById(id);
            return Ok(libro);
        }
    }
}
