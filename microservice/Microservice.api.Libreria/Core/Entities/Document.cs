using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Microservice.api.Libreria.Core.Entities
{
    public class Document : IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public DateTime CreateDate => DateTime.Now;
    }
}
