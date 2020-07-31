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
                var tokens = account.Tokens;
                var response = await MercadoLivreBoundry.GetUserData(account.Tokens.AccessToken);
                //ValidateJsonDeserialization.Execute(response);
                
                var isOk = response.IsDeserializedWithDataModel;
                
                if (!isOk)
                {
                    tokens = account.Tokens = await AccountUseCaseController.RefreshAndUpdateTokens(account.Id.ToString());
                }
                
                return tokens;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
