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
        public async Task<Account> Execute(string id)
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
    }
}
