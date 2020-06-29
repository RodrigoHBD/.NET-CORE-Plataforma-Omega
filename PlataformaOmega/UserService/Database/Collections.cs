using MongoDB.Driver;
using UserService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService
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
        public static IMongoCollection<User> Users { get; set; }

        public static async Task InitializeAsync()
        {
            Users = Connection.GetCollection<User>("Users");
        }
    }
}
