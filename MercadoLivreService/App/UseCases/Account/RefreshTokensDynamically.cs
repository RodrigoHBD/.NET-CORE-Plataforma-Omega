using MercadoLivreService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.UseCases
{
    public class RefreshTokensDynamically
    {
        public async Task Execute(string id)
        {
            try
            {
                await SetAccount(id);
                var tokenIsExpired = GetIsTokneExpired();

                if (tokenIsExpired)
                {
                    await UpdateTokens();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task ExecuteByMercadoLivreId(long id)
        {
            try
            {
                await SetAccountByMercadoLivreId(id);
                var tokenIsExpired = GetIsTokneExpired();

                if (tokenIsExpired)
                {
                    await UpdateTokens();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private Account Account { get; set; }

        private async Task SetAccount(string id)
        {
            Account = await AccountUseCases.GetById.Execute(id);
        }

        private async Task SetAccountByMercadoLivreId(long id)
        {
            Account = await AccountUseCases.GetByMercadoLivreId.Execute(id);
        }

        private bool GetIsTokneExpired()
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

        private async Task UpdateTokens()
        {
            var id = Account.Id.ToString();
            var tokens = await AccountUseCases.GetRefreshedTokens.Execute(Account.Tokens.RefreshToken);
            await AccountUseCases.UpdateAccountTokens.Execute(id, tokens);
        }
    }
}
