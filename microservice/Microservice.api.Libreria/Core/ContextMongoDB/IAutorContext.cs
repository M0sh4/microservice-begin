using Microservice.api.Libreria.Core.Entities;
using MongoDB.Driver;

namespace Microservice.api.Libreria.Core.ContextMongoDB
{
    public interface IAutorContext
    {
        IMongoCollection<Autor> Autores { get;}
    }
}
