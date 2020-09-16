using MercadoLivreLibrary;
using MercadoLivreLibrary.Models;
using MercadoLivreService.App.Boundries.DAO;
using MercadoLivreService.App.Factories;
using MercadoLivreService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.UseCases
{
    public class CreateAccount
    {
        public async Task<string> Execute()
        {
            try
            {
                await SetAccount();
                await SetTokens();
                await SetAccountDetail();
                return Account.Id.ToString();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public CreateAccount(AddAccountRequest request) => Request = request;

        private AddAccountRequest Request { get; }

        private Account Account { get; set; }

        private AccessTokensJson Tokens { get; set; }

        private async Task SetAccount() 
        {
            Account = new AccountFactory(Request).GetAccount();
            await AccountDAO.Methods.Register.Execute(Account);
        }

        private async Task SetTokens() 
        {
            Tokens = await MercadoLivreLib.Methods.Tokens.ExchangeAuthCodeForTokens
                .Execute(Request.AuthCode);
            await AccountDAO.Methods.Set.Tokens(Account.Id.ToString(), Tokens);
        }   

        private async Task SetAccountDetail()
        {
            var details = await MercadoLivreLib.Methods.Account.GetDetail.Execute(Tokens.access_token);
            var id = Account.Id.ToString();

            await AccountDAO.Methods.Set.Nickname(id, details.nickname);
            await AccountDAO.Methods.Set.Email(id, details.email);
            await AccountDAO.Methods.Set.MercadoLivreId(id, details.id);
        }
            
    }
}
