using Microservice.api.Libreria.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservice.api.Libreria.Repository
{
    public interface IAutorRepository
    {
        Task<IEnumerable<Autor>> GetAutores();
    }
}
