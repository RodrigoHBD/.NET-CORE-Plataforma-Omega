using MercadoLivreService.App.Boundries.DAO;
using MercadoLivreService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.UseCases.Tokens
{
    public class GetValidAccessToken
    {
        public async Task<string> ForAccount(long id)
        {
            try
            {
                await SetAccount(id);
                return await GetToken();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private Account Account { get; set; }

        private async Task SetAccount(long id) => 
            Account = await AccountDAO.Methods.Get.ByMercadoLivreId(id);

        private async Task<string> GetToken()
        {
            var isTokenExpired = GetIsTokenExpired();

            if (isTokenExpired)
            {
                return await TokensUseCases.Refresh.Execute(Account.Id.ToString());
            }
            return Account.Tokens.AccessToken;
        }

        private bool GetIsTokenExpired()
        {
            var timezone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            var now = DateTime.Now;
            var tokenExpirationDate = TimeZoneInfo.ConvertTime(Account.Dates.TokensLastRefreshedAt.AddMinutes(350), timezone);
            var dateComparation = DateTime.Compare(now, tokenExpirationDate);

            if (dateComparation > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
