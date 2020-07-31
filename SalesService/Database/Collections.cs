using MongoDB.Driver;
using SalesService.App.Models;
using SalesService.ServerGrid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesService
{
    public class Collections
    {
        public static IMongoCollection<Platform> Platforms { get; set; }

        public static IMongoCollection<Sale> Sales { get; set; }
  
        public static async Task InitializeAsync()
        {
            InitializeServerCollections();
            InitializeCommonCollections();
        }

        private static void InitializeServerCollections()
        {
            Sales = Database.ServerConnection.GetCollection<Sale>("Sales");
        }

        private static void InitializeCommonCollections()
        {
            Platforms = Database.CommonConnection.GetCollection<Platform>("Platforms");
        }

    }
}
