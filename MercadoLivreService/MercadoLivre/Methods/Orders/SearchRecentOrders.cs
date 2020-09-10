using MercadoLivreService.App.Models;
using MercadoLivreService.HttpClientLibrary;
using MercadoLivreService.MercadoLivre.Models.In;
using MercadoLivreService.MercadoLivreModels.Out;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.MercadoLivre.Methods.Orders
{
    public class SearchRecentOrders : MercadoLivreMethod
    {
        public async Task<ApiCallResponse> Execute()
        {
            try
            {
                var uri = GetUri();
                var resp = await HttpClient.Get(uri);
                return MercadoLivreLib.ResponseHandler.HandleApiResponse<OrderSearchJson>(resp);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public SearchRecentOrders(Account account, PaginationIn pagination)
        {
            AccountId = account.MercadoLivreId.ToString();
            AccessToken = account.Tokens.AccessToken;
            Pagination = pagination;
        }

        private string AccountId { get; }

        private string AccessToken { get; }

        private PaginationIn Pagination { get; }

        private string GetUri()
        {
            return $"{BaseUri}/orders/search/recent?seller={AccountId}&access_token={AccessToken}" +
                $"&offset={Pagination.Offset}&limit={Pagination.Limit}";
        }
    }
}
