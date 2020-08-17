using MercadoLivreService.MercadoLivre.Models;
using MercadoLivreService.MercadoLivre.Models.In;
using MercadoLivreService.MercadoLivreModels.Out;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.UseCases.Shipment
{
    public class GetDetails
    {
        public async Task<ShipmentJson> Execute(long accountId, long shippmentId)
        {
			try
			{
				var call = await BuildCall(accountId, shippmentId);
				var response = await MakeTheCall(call);
				return HandleResponse(response);
			}
			catch (Exception)
			{
				throw;
			}
        }

		private async Task<GetShipmentDetailApiCall> BuildCall(long accountId, long shippmentId)
		{
			var account = await AccountUseCases.GetByMercadoLivreId.Execute(accountId);
			var tokens = await GetValidAccessToken.Execeute(account.Id.ToString());

			return new GetShipmentDetailApiCall()
			{
				AccessToken = tokens.AccessToken,
				ShipmentId = shippmentId
			};
		}

		private async Task<ApiCallResponse> MakeTheCall(GetShipmentDetailApiCall call)
		{
			return await MercadoLivreLib.Methods.Shipment.GetDetail.Execute(call);
		}

		private ShipmentJson HandleResponse(ApiCallResponse response)
		{
			var results = ApiCallUseCases.HandleApiCallResponse.Execute<ShipmentJson>(response);
			return results;
		}
	}
}
