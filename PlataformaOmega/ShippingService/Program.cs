using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using ShippingService.App;
using ShippingService.Correios;

namespace ShippingService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AppInitializer.InitializeAsync().Wait();
            CreateHostBuilder(args).Build().Run();
        }

        // Additional configuration is required to successfully run gRPC on macOS.
        // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(options => 
                    {
                        options.ListenLocalhost(5000);
                    });
                    webBuilder.UseStartup<Startup>();
                });
    }
}
