using Gateway.Routes;
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
                DefaultRouter.ConfigureRoutes(app, env);
                ApiRouter.ConfigureRoutes(app, env);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
