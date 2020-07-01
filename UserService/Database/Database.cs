using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService
{
    public class Database
    {
        private static string ConnectionString { get; } = "mongodb+srv://SystemAdmin:Gremio2020@servicescluster-ar74g.gcp.mongodb.net/test?retryWrites=true&w=majority";

        private static string DatabaseName { get; } = "UserService";

        public static IMongoDatabase Connection { get; private set; }

        public static async Task Connect()
        {
            try
            {
                var client = new MongoClient(ConnectionString);
                Connection = client.GetDatabase(DatabaseName);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
