using MercadoLivreService.HttpClientLibrary;
using MercadoLivreService.MercadoLivre.Models;
using MercadoLivreService.MercadoLivre.Models.In;
using MercadoLivreService.MercadoLivreModels.Out;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.MercadoLivre.Methods.Shipping
{
    public class GetDetail : MercadoLivreMethod
    {
        public async Task<ApiCallResponse> Execute(GetShipmentDetailApiCall call)
        {
            try
            {
                var uri = BuildUri(call);
                var response = await HttpClient.Get(uri);
                return await MercadoLivreLib.ResponseHandler.HandleApiResponse<ShipmentJson>(response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string BuildUri(GetShipmentDetailApiCall call)
        {
            return $"{BaseUri}/shipments/{call.ShipmentId}?access_token={call.AccessToken}";
        }
    }
}
