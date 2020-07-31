using MercadoLivreService.HttpClientLibrary;
using MercadoLivreService.MercadoLivreModels;
using MercadoLivreService.MercadoLivreModels.In;
using MercadoLivreService.MercadoLivreModels.Out;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MercadoLivreService.MercadoLivre.Methods
{
    public class GetAccountDetails : MercadoLivreMethod
    {
        public async Task<ApiCallResponse> Execute(ApiCall call)
        {
            try
            {
                ValidateCall(call);
                var apiCall = await MakeTheCall(call);
                return await MercadoLivreLib.ResponseHandler.HandleApiResponse<AccountSelfDataJson>(apiCall);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<HttpResponseMessage> MakeTheCall(ApiCall call)
        {
            try
            {
                var uri = $"{BaseUri}/users/me?access_token={call.AccessToken}";
               return await HttpClientLibrary.HttpClient.Get(uri);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ValidateCall(ApiCall call)
        {
            try
            {

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
