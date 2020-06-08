using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.Models
{
    public class Brand
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; } = "";
        public string Abbreviation { get; set; } = "";
    }
}
