using MercadoLivreService.App.Boundries.DAO;
using MercadoLivreService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.UseCases
{
    public class RegisterAccount
    {
        public static async Task Execute(Account account)
        {
            try
            {
                await AccountDAO.RegisterAccount(account);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
