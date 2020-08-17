using SalesService.App.Boundries;
using SalesService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesService.App.UseCases
{
    public class GetSaleByMarketplaceId
    {
        public async Task<Sale> Execute(string id)
        {
			try
			{
				return await SaleDAO.Queries.GetByMarketplaceId.Execeute(id);
			}
			catch (Exception)
			{
				throw;
			}
        }
    }
}
