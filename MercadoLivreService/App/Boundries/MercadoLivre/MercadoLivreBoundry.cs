using MercadoLivreService.App.Boundries.MercadoLivreAdapters;
using MercadoLivreService.App.Boundries.MercadoLivreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Boundries
{
    public class MercadoLivreBoundry
    {
        public static async Task<AuthCodeExchangeResult> ExchangeAuthorizationCodeForAccessTokens(string code)
        {
            try
            {
                var json = await MercadoLivreLib.ExchangeCodeForTokens(code);
                return AuthCodeExchangeJsonAdapter.Adapt(json);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
