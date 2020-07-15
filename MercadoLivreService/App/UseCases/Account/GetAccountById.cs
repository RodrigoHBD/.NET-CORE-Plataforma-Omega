using MercadoLivreService.App.Boundries.DAO;
using MercadoLivreService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.UseCases
{
    public class GetAccountById
    {
        public static async Task<Account> Execute(string id)
        {
            try
            {
                return await AccountDAO.GetAccountById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
