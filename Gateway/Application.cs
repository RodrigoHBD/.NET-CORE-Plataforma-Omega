using Gateway.App;
using Gateway.gRPC.Client;
using Gateway.gRPC.Client.Sale;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway
{
    public class Application
    {
        public static async Task InitializeAsync(string [] args)
        {
            try
            {
                Console.WriteLine("Initializing Gateway");
                await RunInitializationRoutine();
                StartHttpServer(args);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }

        private static async Task RunInitializationRoutine()
        {
            try
            {
                InitializeDatabase();
                ViewClient.Initialize();
                ShippingClient.Initialize();
                MercadoLivreClient.Initialize();
                SaleClient.Initialize();
            }
            catch (Exception e)
            {
                HandleInitializationFailure(e);
            }
        }

        private static void HandleInitializationFailure(Exception e)
        {

        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder => 
            {
                webBuilder.UseIISIntegration();
                webBuilder.UseStartup<Startup>();
            });
        }

        private static void StartHttpServer(string[] args)
        {
            var hostBuilder = CreateHostBuilder(args);
            hostBuilder.Build().Start();
        }

        private static void InitializeDatabase()
        {
            Database.Connect().Wait();
            Collections.InitializeAsync().Wait();
        }
    }
}
