using MongoDB.Driver;
using ShippingService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService
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

        public static IMongoCollection<Package> Packages { get; set; }

        public static IMongoCollection<Shipment> Shipments { get; set; }

        public static async Task InitializeAsync()
        {
            Packages = Connection.GetCollection<Package>("Packages_Dev");
            Shipments = Connection.GetCollection<Shipment>("Shipment");
        }
    }
}
