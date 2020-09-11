using HttpClientLibrary;
using MercadoLivreLibrary.Models;
using MercadoLivreService.MercadoLivreModels.Out;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreLibrary.Methods.Order
{
    public class GetDetails : MercadoLivreMethod
    {
        public async Task<JsonResponse> Execute(dynamic orderId, dynamic accountId, string token)
        {
            try
            {
                var req = GetRequest(orderId, accountId, token);                
                var json = await HttpClientLib.GetDeserializedJson<OrderDetailJson, ErrorJson> (req);
                return json;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string GetUri(string orderId)
        {
            return $"{BaseUri}/orders/{orderId}";
        }

        private List<UriParam> GetParams(dynamic orderId, dynamic accountId, string token)
        {
            return new List<UriParam>()
            {
                new UriParam(){ Name = "seller", Data = accountId },
                new UriParam(){ Name = "access_token", Data = token },
                new UriParam(){ Name = "q", Data = orderId }
            };
        }

        private GetRequest GetRequest(dynamic orderId, dynamic accountId, string token)
        {
            return new GetRequest() 
            {
                Uri = GetUri(orderId),
                Params = GetParams(orderId, accountId, token)
            };
        }
    }
}
