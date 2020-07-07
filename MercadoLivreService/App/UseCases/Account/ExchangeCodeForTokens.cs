using MercadoLivreService.App.Boundries;
using MercadoLivreService.App.Boundries.MercadoLivreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.UseCases
{
    public class ExchangeCodeForTokens
    {
        public static async Task<AuthCodeExchangeResult> Execute(string code)
        {
            try
            {
                return await MercadoLivreBoundry.ExchangeAuthorizationCodeForAccessTokens(code);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
