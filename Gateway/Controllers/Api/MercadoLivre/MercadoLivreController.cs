using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Gateway.Controllers.Api.MercadoLivreModels.Input;
using Gateway.Controllers.Api.MercadoLivreAdapters;
using Gateway.gRPC.Client;
using Gateway.Controllers.Api.MercadoLivreAdapter;
using Gateway.Controllers.Api.MercadoLivre;
using Gateway.gRPC.Client.MercadoLivreProto;
using System.Text.Json;

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

        [HttpGet]
        [Route("app-id")]
        public async Task<IActionResult> GetAppId()
        {
            try
            {
                var grpcStringResp = await MercadoLivreClient.GetAppId();
                return new ContentResult()
                {
                    Content = grpcStringResp.Data,
                    ContentType = "application/json",
                    StatusCode = 200
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("process-authcode-exchange")]
        public async Task ProcessAuthCodeExchange(string code, string metadata = null)
        {
            try
            {
                var request = new AddAccountReq()
                {
                    AuthCode = code
                };
                var grpcRequest = AddAccountReqAdapter.AdaptToGrpc(request);
                await MercadoLivreClient.AddAccount(grpcRequest);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("account/by-mercado-livre-id")]
        public async Task<IActionResult> GetAccountByMarketplaceId(long id)
        {
            try
            {
                var grpcReq = new GrpcGetByIdReq() { Id = id.ToString() };
                var grpcResp = await MercadoLivreClient.GetAccountByMarketplaceId(grpcReq);
                var json = JsonSerializer.Serialize(grpcResp);
                return new ContentResult() 
                { 
                    ContentType = "application/json",
                    Content = json,
                    StatusCode = 200
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("notification")]
        public async Task HandleNotification(Notification notification)
        {
            try
            {
                Collections.MLNotifications.InsertOne(notification);
                await NotificationHandler.HandleNotification(notification);
                return;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
