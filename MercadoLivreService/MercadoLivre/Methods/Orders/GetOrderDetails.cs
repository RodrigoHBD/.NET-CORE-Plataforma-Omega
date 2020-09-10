using MercadoLivreService.HttpClientLibrary;
using MercadoLivreService.MercadoLivreModels.In;
using MercadoLivreService.MercadoLivreModels.Out;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.MercadoLivre.Methods.Orders
{
    public class GetOrderDetails : MercadoLivreMethod
    {
        public async Task<ApiCallResponse> Execute(SearchOrdersApiCall call)
        {
            try
            {
                var uri = GetUri(call);
                var response = await HttpClient.Get(uri);
                var data = MercadoLivreLib.ResponseHandler.HandleApiResponse<OrderDetailJson>(response);
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string GetUri(SearchOrdersApiCall call)
        {
            return $"{BaseUri}/orders/{call.OrderId}?access_token={call.AccessToken}&seller={call.SellerId}" +
                $"&q={call.OrderId}";
        }
    }
}
