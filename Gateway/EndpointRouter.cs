using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway
{
    public class EndpointRouter
    {
        public static void ConfigureRoutes(IApplicationBuilder app, IWebHostEnvironment env)
        {
            try
            {
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                    endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=View}/{action=Index}");

                });
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
