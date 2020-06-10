using Gateway.App.UseCases;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Controllers
{
    public class ViewController
    {
        public static async Task HandleRequestForHtml(HttpContext context, IViewSelector viewSelector)
        {
            try
            {
                var html = await UseCaseController.GetHtmlAsync(viewSelector.Path);
                await context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes(html));
            }
            catch (Exception e)
            {
                await context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes(e.Message));
            }
        }

        public static async Task HandleRequestForStaticFile(HttpContext context, StaticFileSelector fileSelector)
        {
            try
            {
                var file = await UseCaseController.GetStaticFileAsync(fileSelector.Path);
                await context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes(file));
            }
            catch (Exception e)
            {
                await context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes(e.Message));
            }
        }
    }

}
