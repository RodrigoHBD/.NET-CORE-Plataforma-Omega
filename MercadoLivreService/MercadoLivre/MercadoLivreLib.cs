using MercadoLivreService.App;
using MercadoLivreService.App.UseCases;
using MercadoLivreService.HttpClientLibrary;
using MercadoLivreService.MercadoLivreModels.Out;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService
{
    public class MercadoLivreLib
    {
        private static string BaseUri { get; } = "https://api.mercadolibre.com";

        private static string AuthUri { get { return $"{BaseUri}/oauth/token?grant_type=authorization_code"; } }

        private static MercadoLivreAppCredentials Credentials { get { return AppCredentials.GetInstance(); } }

        public static async Task<AuthCodeExchangeJson> ExchangeCodeForTokens(string code)
        {
            try
            {
                var credentials = Credentials;
                var uri = $"{AuthUri}&client_id={credentials.AppId}&client_secret={credentials.AppToken}&code={code}&redirect_uri=https://plataforma-omega.brazilsouth.cloudapp.azure.com";
                return await HttpClient.Post<AuthCodeExchangeJson>(uri, null);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
