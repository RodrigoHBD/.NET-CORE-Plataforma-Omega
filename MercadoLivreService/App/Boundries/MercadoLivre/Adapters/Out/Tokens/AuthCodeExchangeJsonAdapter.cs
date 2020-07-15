using MercadoLivreService.App.Boundries.MercadoLivreModels;
using MercadoLivreService.MercadoLivreModels.Out;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Boundries.MercadoLivreAdapters
{
    public class AuthCodeExchangeJsonAdapter
    {
        public static AuthCodeExchangeResult Adapt(AccessTokensJson json)
        {
            try
            {
                return new AuthCodeExchangeResult()
                {
                    AccessToken = json.access_token,
                    RefreshToken = json.refresh_token,
                    UserId = json.user_id,
                    ExpiresInMiliseconds = json.expires_in
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
