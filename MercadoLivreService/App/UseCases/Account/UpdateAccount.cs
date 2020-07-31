using MercadoLivreService.App.Boundries.DAO;
using MercadoLivreService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.UseCases
{
    public class UpdateAccount
    {
        public static async Task Execute(string id, AccountUpdate update)
        {
			try
			{
				await AccountDAO.UpdateAccount(id, update);
			}
			catch (Exception)
			{
				throw;
			}
        }
    }
}
