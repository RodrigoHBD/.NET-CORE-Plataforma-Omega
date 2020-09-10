using MercadoLivreService.App.Boundries.DAO;
using MercadoLivreService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.UseCases
{
    public class UpdateAccountTokens
    {
        public async Task Execute(string id, AccountTokens tokens)
        {
            try
            {
                await AccountDAO.UpdateAccountTokens(id, tokens);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
