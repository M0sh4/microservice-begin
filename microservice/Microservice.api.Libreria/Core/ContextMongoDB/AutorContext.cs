using Microservice.api.Libreria.Core.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Microservice.api.Libreria.Core.ContextMongoDB
{
    public class AutorContext : IAutorContext
    {
        private readonly IMongoDatabase _database;
        public AutorContext(IOptions<MongoSettings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _database = client.GetDatabase(options.Value.Database);
        }
        public IMongoCollection<Autor> Autores => _database.GetCollection<Autor>("Autor");
    }
}
