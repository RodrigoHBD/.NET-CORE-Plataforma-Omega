using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gateway.Controllers.Shipping.Input;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingController : ControllerBase
    {
        [Route("new-package")]
        [HttpPost]
        public async Task GetPackageDataAsync(PackageSearch search)
        {
            try
            {

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [Route("get-package")]
        [HttpGet]
        public async Task GetPackageDataAsync(string id)
        {
            try
            {

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
