using MercadoLivreService.MercadoLivreModels.In;
using MercadoLivreService.MercadoLivreModels.Out;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.UseCases.Order
{
    public class GetDetails
    {
        public async Task<OrderDetailJson> Execute(long accountId, string orderId)
        {
			try
			{
				var call = await BuildCall(accountId, orderId);
				var response = await MakeTheCall(call);
				return HandleResponse(response);
			}
			catch (Exception)
			{
				throw;
			}
        }

		private OrderDetailJson HandleResponse(ApiCallResponse response)
		{
			var results = ApiCallUseCases.HandleApiCallResponse.Execute<OrderDetailJson>(response);
			return results;
		}

		private async Task<SearchOrdersApiCall> BuildCall(long accountId, string orderId)
		{
			var account = await AccountUseCases.GetByMercadoLivreId.Execute(accountId);
			var tokens = await GetValidAccessToken.Execeute(account.Id.ToString());
			var call = new SearchOrdersApiCall()
			{
				AccessToken = tokens.AccessToken,
				BuyerId = account.MercadoLivreId,
				OrderId = orderId
			};
			return call;
		}

		private async Task<ApiCallResponse> MakeTheCall(SearchOrdersApiCall call)
		{
			return await MercadoLivreLib.Methods.Order.GetDetails.Execute(call);
		}

    }
}
