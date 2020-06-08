using MongoDB.Driver;
using ProductService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService
{
    public class Collections
    {
        private static IMongoDatabase Connection
        {
            get
            {
                return Database.Connection;
            }
        }
        public static IMongoCollection<Product> Products { get; set; }
        public static IMongoCollection<PhysicalProduct> PhysicalProducts { get; set; }
        public static IMongoCollection<Brand> Brands { get; set; }
        public static async Task InitializeAsync()
        {
            Products = Connection.GetCollection<Product>("Products");
            PhysicalProducts = Connection.GetCollection<PhysicalProduct>("PhysicalProducts");
            Brands = Connection.GetCollection<Brand>("Brands");
        }
    }
}
