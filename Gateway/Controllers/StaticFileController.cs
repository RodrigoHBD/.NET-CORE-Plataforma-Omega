using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gateway.App.UseCases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Controllers
{
    //[Route("js/{path?}/~")]
    //[Route("css/{path?}/~")]
    public class StaticFileController : ControllerBase
    {
        [Route("js/{*path}")]
        public IActionResult GetJsFile(string path)
        {
            try
            {
                path = $"\\Assets\\js\\{path}";
                var file = UseCaseController.GetStaticFileAsync(path).Result;
                return new ContentResult()
                {
                    Content = file,
                    ContentType = "application/javascript"
                };
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [Route("css/{*path}")]
        public IActionResult GetCssFile(string path)
        {
            try
            {
                path = $"\\Assets\\css\\{path}";
                var file = UseCaseController.GetStaticFileAsync(path).Result;
                return new ContentResult()
                {
                    Content = file,
                    ContentType = "text/css"
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
