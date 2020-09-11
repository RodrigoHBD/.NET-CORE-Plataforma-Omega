﻿using MercadoLivreService.App.Boundries.DAO;
using MercadoLivreService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.UseCases
{
    public class GetAccountByMercadoLivreId
    {
        public async Task<Account> Execute(long id)
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
