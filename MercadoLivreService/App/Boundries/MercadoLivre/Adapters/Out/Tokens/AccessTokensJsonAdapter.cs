using MercadoLivreService.App.Models;
using MercadoLivreService.MercadoLivreModels.Out;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Boundries.MercadoLivreAdapters
{
    public class AccessTokensJsonAdapter
    {
        public static AccountTokens AdaptToAccountTokens(AccessTokensJson json)
        {
            try
            {
                return new AccountTokens()
                {
                    AccessToken = json.access_token,
                    RefreshToken = json.refresh_token
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
