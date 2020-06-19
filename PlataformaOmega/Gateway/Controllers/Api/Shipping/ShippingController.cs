using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gateway.Controllers.Api.Shipping.Factories;
using Gateway.Controllers.Api.Shipping.Models.Input;
using Gateway.Controllers.Shipping.Input;
using Gateway.gRPC.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingController : ControllerBase
    {
        [Route("get-package")]
        [HttpGet]
        public async Task<IActionResult> GetPackageDataAsync(string id)
        {
            try
            {
                var packageData = await ShippingClient.GetPackageDataAsync(id);
                return new ContentResult()
                {
                    Content = PackageDataFactory.MakeSerialized(packageData),
                    ContentType = "application/json"
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [Route("search-package")]
        [HttpPost]
        public async Task<IActionResult> SearchPackageData(PackageSearch search)
        {
            try
            {
                var results = await ShippingClient.SearchPackagesAsync(search);
                return new ContentResult() 
                {
                    Content = PackageListFactory.MakeSerialized(results),
                    ContentType = "application/json"
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [Route("new-package")]
        [HttpPost]
        public async Task CreateNewPackage(NewPackage newPackage)
        {
            try
            {
                var response = await ShippingClient.CreateNewPackage(newPackage);
                var isOk = response.Ok == true;
                return;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [Route("delete-package")]
        [HttpDelete]
        public async Task DeletePackageAsync(string id)
        {
            try
            {
                await ShippingClient.DeletePackage(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
