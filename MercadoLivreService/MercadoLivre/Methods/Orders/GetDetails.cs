using HttpClientLibrary;
using MercadoLivreLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreLibrary.Methods.Order
{
    public class GetDetails : MercadoLivreMethod
    {
        public async Task<OrderDetailJson> Execute(long orderId, long accountId, string token)
        {
            try
            {
                var req = GetRequest(orderId, accountId, token);                
                var json = await HttpClientLib.Get<OrderDetailJson, ErrorJson> (req);
                return json;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string GetUri(long orderId)
        {
            return $"{BaseUri}/orders/{orderId}";
        }

        private List<UriParam> GetParams(long orderId, long accountId, string token)
        {
            return new List<UriParam>()
            {
                new UriParam(){ Name = "seller", Data = accountId.ToString() },
                new UriParam(){ Name = "access_token", Data = token },
                new UriParam(){ Name = "q", Data = orderId.ToString() }
            };
        }

        private GetRequest GetRequest(long orderId, dynamic accountId, string token)
        {
            return new GetRequest() 
            {
                Uri = GetUri(orderId),
                Params = GetParams(orderId, accountId, token)
            };
        }
    }
}
