using MercadoLivreService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Boundries.AccountDAO
{
    public class Register : AccountDAOMethod
    {
        public async Task<string> Execute(Account account)
        {
            try
            {
                await Collections.Accounts.InsertOneAsync(account);
                return account.Id.ToString();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
