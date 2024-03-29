﻿using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Microservice.api.Libreria.Core.Entities
{
    [BsonCollection("Libro")]
    public class LibroEntity : Document
    {
        [BsonElement("titulo")]
        public string Titulo { get; set; }

        [BsonElement("descripcion")]
        public string Descripcion { get; set; }
        [BsonElement("precio")]
        public int Precio { get; set; }
        [BsonElement("fechaPublicacion")]
        public DateTime? FechaPublicacion { get; set; }
        [BsonElement("autor")]
        public AutorEntity autor { get; set; }
    }
}
