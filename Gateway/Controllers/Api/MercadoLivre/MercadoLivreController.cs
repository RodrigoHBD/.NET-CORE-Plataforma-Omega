using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Gateway.Controllers.Api.MercadoLivreModels.Input;
using Gateway.Controllers.Api.MercadoLivreAdapters;
using Gateway.gRPC.Client;

namespace Gateway.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MercadoLivreController : ControllerBase
    {
        [Route("search-accounts")]
        [HttpPost]
        public async Task<IActionResult> SearchAccounts(SearchAccountsReq request)
        {
            try
            {
                var grpcRequest = SearchAccountsReqAdapter.AdaptToGrpc(request);
                var grpcResponse = await MercadoLivreClient.SearchAccounts(grpcRequest);

                return new ContentResult() 
                {
                    Content = GrpcAccountListAdapter.AdaptSerialized(grpcResponse),
                    ContentType = "application/json",
                    StatusCode = 200
                };

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
