using HttpClientLibrary;
using MercadoLivreLibrary.Models;
using MercadoLivreLibrary.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreLibrary.Methods.Order
{
    public class SearchRecentOrders : MercadoLivreMethod
    {
        public async Task<OrderSearchJson> Execute()
        {
            try
            {
                var req = GetRequest();
                var json = await HttpClientLib.Get<OrderSearchJson, ErrorJson>(req);
                return json;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public SearchRecentOrders(long accountId, string token, Pagination pagination)
        {
            AccountId = accountId;
            AccessToken = token;
            Pagination = pagination;
        }

        private long AccountId { get; }

        private string AccessToken { get; }

        private Pagination Pagination { get; }

        private string GetUri()
        {
            return $"{BaseUri}/orders/search/recent";
        }

        private List<UriParam> GetParams()
        {
            return new List<UriParam>()
            {
                new UriParam(){ Name = "seller", Data = AccountId.ToString() },
                new UriParam(){ Name = "access_token", Data = AccessToken },
                new UriParam(){ Name = "offset", Data = Pagination.Offset.ToString() },
                new UriParam(){ Name = "limit", Data = Pagination.Limit.ToString() },
            };
        }

        private GetRequest GetRequest()
        {
            return new GetRequest()
            {
                Uri = GetUri(),
                Params = GetParams()
            };
        }
    }
}
