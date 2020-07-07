using MongoDB.Driver;
using MercadoLivreService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService
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

        public static IMongoCollection<Account> Accounts { get; set; }
      
        public static async Task InitializeAsync()
        {
            Accounts = Connection.GetCollection<Account>("Accounts");
        }
    }
}
