using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Microservice.api.Libreria.Core.Entities
{
    public interface IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        string Id { get; set; }

        DateTime CreateDate { get; }
    }
}
