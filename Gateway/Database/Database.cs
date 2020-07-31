using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway
{
    public class Database
    {
        private static string ConnectionString { get; } = "mongodb+srv://SystemAdmin:Gremio2020@servicescluster-ar74g.gcp.mongodb.net/test?retryWrites=true&w=majority";

        private static string DatabaseName { get; } = "GatewayService";

        private static string CommonDatabaseName { get; } = "Common";

        public static IMongoDatabase ServerConnection { get; private set; }

        public static IMongoDatabase CommonConnection { get; private set; }

        public static async Task Connect()
        {
            try
            {
                var client = new MongoClient(ConnectionString);
                ServerConnection = client.GetDatabase(DatabaseName);
                CommonConnection = client.GetDatabase(CommonDatabaseName);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
