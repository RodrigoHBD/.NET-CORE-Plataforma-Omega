using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.Models
{
    public class Category
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
    }
}
