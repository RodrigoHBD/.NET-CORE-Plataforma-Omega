using MercadoLivreService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.UseCases
{
    public class AccountUseCaseController
    {
        public static async Task AddNewAccountAsync(IAddAccountRequest request)
        {
            try
            {
                var accountTokens = await ExchangeCodeForTokens.Execute(request.AuthCode);
                var account = CreateAccount.Execute(request, accountTokens);
                await RegisterAccount.Execute(account);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
