using MercadoLivreService.App.Boundries.DAO;
using MercadoLivreService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.UseCases
{
    public class GetAccount
    {
        public async Task<Account> ById(string id)
        {
            try
            {
                return await AccountDAO.Methods.Get.ById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Account> ByMercadoLivreId(long id)
        {
            try
            {
                return await AccountDAO.Methods.Get.ByMercadoLivreId(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
