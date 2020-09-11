using MercadoLivreLibrary;
using MercadoLivreLibrary.Models;
using MercadoLivreService.App.Boundries.DAO;
using MercadoLivreService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.UseCases.Tokens
{
    public class Refresh
    {
        public async Task<string> Execute(string id)
        {
            try
            {
                await SetAccount(id);
                await SetTokens();
                await UpdateTokens();
                return Tokens.access_token;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private Account Account { get; set; }

        private AccessTokensJson Tokens { get; set; }

        private async Task SetAccount(string id) =>
            Account = await AccountDAO.Methods.Get.ById(id);

        private async Task SetTokens() =>
            Tokens = await MercadoLivreLib.Methods.Tokens.Refresh.Execute(Account.Tokens.RefreshToken);

        private async Task UpdateTokens() => await AccountDAO.Methods.Set
            .Tokens(Account.Id.ToString(),Tokens);

    }
}
