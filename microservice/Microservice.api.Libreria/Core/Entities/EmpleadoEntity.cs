using Microservice.api.Libreria.Repository;
using MongoDB.Bson.Serialization.Attributes;

namespace Microservice.api.Libreria.Core.Entities
{
    [BsonCollection("Empleado")]
    public class EmpleadoEntity : Document
    {
        [BsonElement("nombre")]
        public string Nombre { get; set; }
    }
}
