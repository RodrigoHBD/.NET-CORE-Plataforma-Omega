using MercadoLivreService.App;
using MercadoLivreService.HttpClientLibrary;
using MercadoLivreService.MercadoLivre.Models.In;
using MercadoLivreService.MercadoLivreModels.In;
using MercadoLivreService.MercadoLivreModels.Out;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MercadoLivreService.MercadoLivre.Methods.Tokens
{
    public class ExchangeAuthCodeForTokens : MercadoLivreMethod
    {
        private MercadoLivreAppCredentials Credentials { get { return MercadoLivreLib.Credentials; } }

        private string RedirectUri { get; } = "https://plataforma-omega.brazilsouth.cloudapp.azure.com/api/mercadolivre/process-authcode-exchange";

        public async Task<ApiCallResponse> Execute(ExchangeAuthCodeCall call)
        {
            try
            {
                ValidateCall(call);
                var response = await MakeTheCall(call);
                return await MercadoLivreLib.ResponseHandler.HandleApiResponse<AccessTokensJson>(response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<HttpResponseMessage> MakeTheCall(ExchangeAuthCodeCall call)
        {
            try
            {
                var uri = $"{AuthCodeUri}&client_id={Credentials.AppId}&client_secret={Credentials.AppToken}&code={call.Code}&redirect_uri={RedirectUri}";
                return await HttpClientLibrary.HttpClient.Get(uri);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ValidateCall(ExchangeAuthCodeCall call)
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
