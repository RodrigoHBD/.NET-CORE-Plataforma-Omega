using ShippingService.gRPC.Client.MercadoLivre;
using ShippingService.HttpClientLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App
{
    public class AppInitializer
    {
        public static async Task InitializeAsync()
        {
            try
            {
                await InitializeDatabaseAsync();
                InitializeHttpClient();
                InitializeRoutines();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static async Task InitializeDatabaseAsync()
        {
            try
            {
                await Database.Connect();
                await Collections.InitializeAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static void InitializeRoutines()
        {
            try
            {
                MercadoLivreClient.Initialize();
                RoutineScheduler.Initialize();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static void InitializeHttpClient()
        {
            HttpClient.Initialize();
        }
    }
}
