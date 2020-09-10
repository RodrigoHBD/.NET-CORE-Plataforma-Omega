using MercadoLivreService.App.Boundries;
using MercadoLivreService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.UseCases
{
    public class GetValidAccessToken
    {
        public static async Task<AccountTokens> Execeute(string id)
        {
            try
            {
                var account = await AccountUseCases.GetById.Execute(id);
                var token = account.Tokens.AccessToken;
                var tokenIsValid = await MercadoLivreBoundry.ValidateAccessToken(token);
                
                if (!tokenIsValid)
                {
                    return await AccountUseCaseController.RefreshAndUpdateTokens(account.Id.ToString());
                }

                return account.Tokens;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
