using MercadoLivreService.App.Boundries;
using MercadoLivreService.App.Boundries.MercadoLivreModels;
using MercadoLivreService.MercadoLivreModels.Out;
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
                var callResult = await MercadoLivreBoundry.ExchangeAuthorizationCodeForAccessTokens(code);
                ValidateJsonDeserialization.Execute(callResult);
                return Adapt(callResult);
            }
            catch (Exception e)
            {
                throw new Exception($"Erro na autenticação com o Mercado Livre: {e.Message}");
            }
        }

        private static AuthCodeExchangeResult Adapt(ApiCallResponse callResponse)
        {
            var tokens = (AccessTokensJson) callResponse.DeserializedJson;

            return new AuthCodeExchangeResult()
            {
                AccessToken = tokens.access_token,
                RefreshToken = tokens.refresh_token,
                UserId = tokens.user_id,
                ExpiresInMiliseconds = tokens.expires_in
            };
        }
    }
}
