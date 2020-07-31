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
                return await MercadoLivreLib.ResponseHandler.HandleApiResponse<OrderDetailJson>(response);
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
