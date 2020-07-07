using MercadoLivreService.App.Boundries.DAO;
using MercadoLivreService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.UseCases
{
    public class SearchAccounts
    {
        public static async Task<IAccountList> Execute(ISearchAccountsReq request)
        {
            try
            {
                return await AccountDAO.SearchAccounts(request);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
