using Gateway.gRPC.Client;
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
                ViewClient.Initialize();
                ShippingClient.Initialize();
                MercadoLivreClient.Initialize();
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
    }
}
