using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MercadoLivreService.App;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace MercadoLivreService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                AppInitializer.InitializeAsync().Wait();
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception e)
            {
                Console.WriteLine("FATAL! ERROR INITIALIZING APPLICATION");
                Console.WriteLine(e);
                Environment.Exit(1);
            }
        }

        // Additional configuration is required to successfully run gRPC on macOS.
        // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel((options) =>
                    {
                        options.ListenLocalhost(5004);
                    });
                    webBuilder.UseStartup<Startup>();
                });
    }
}
