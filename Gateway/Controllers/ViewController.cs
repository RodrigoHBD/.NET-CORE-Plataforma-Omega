using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Gateway.App.UseCases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Gateway.Controllers
{
    public class ViewController : Controller
    {
        [Produces("text/html")]
        [Route("/")]
        [Route("/home")]
        [Route("/index")]
        public IActionResult Index()
        {
            try
            {
                var html = UseCaseController.GetHtmlAsync("\\SPA\\index.html").Result;
                return new ContentResult()
                {
                    Content = html,
                    ContentType = "text/html",
                };
            }
            catch(Exception e)
            {
                return HandleException(e);
            }
        }

        private IActionResult HandleException(Exception e)
        {
            return new ContentResult()
            {
                Content = e.Message,
                ContentType = "text/html",
            };
        }
    }
}
