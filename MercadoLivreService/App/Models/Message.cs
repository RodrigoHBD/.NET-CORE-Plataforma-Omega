using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Models
{
    public class Message
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string Text { get; set; }
    }
}
