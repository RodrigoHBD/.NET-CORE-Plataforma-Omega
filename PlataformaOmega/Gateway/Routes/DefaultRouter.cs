using Gateway.Controllers;
using Gateway.gRPC.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                    endpoints.MapGet("/", async context => 
                    {
                        await ViewController.HandleRequestForHtml(context, new AppViewSelector());   
                    });

                });
                app.Use(async (context, next) => 
                {
                    try
                    {
                        var jsRegex = new Regex(@"/js*");
                        var cssRegex = new Regex(@"/css*");
                        var isJsRoute = jsRegex.IsMatch(context.Request.Path.Value);
                        var isCssRoute = cssRegex.IsMatch(context.Request.Path.Value);

                        if (isJsRoute || isCssRoute)
                        {
                            await ViewController.HandleRequestForStaticFile(context, new StaticFileSelector(context.Request.Path.Value));
                        }

                        await next()
;                    }
                    catch (Exception e)
                    {

                        throw;
                    }
                });
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
