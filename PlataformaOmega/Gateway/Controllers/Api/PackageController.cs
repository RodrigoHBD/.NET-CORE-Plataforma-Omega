using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        [HttpGet("get-data")]
        public IActionResult GetPackageData()
        {
            var id = Request.Query["id"];
            return new ContentResult() { Content = id };
        }
    }
}
