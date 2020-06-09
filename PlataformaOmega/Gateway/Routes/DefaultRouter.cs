using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Routes
{
    public class DefaultRouter
    {
        public static void ConfigureRoutes(IApplicationBuilder app, IWebHostEnvironment env)
        {
            try
            {
                app.UseEndpoints(endpoints =>
                {
                    //endpoints.MapControllers();
                    endpoints.MapGet("/", async context => { });
                });
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
