using MongoDB.Driver;
using SalesService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesService.App.Boundries.SaleDAOQueries
{
    public class GetByMarketplaceId
    {
        public async Task<Sale> Execeute(string id)
        {
			try
			{
				var filter = Builders<Sale>.Filter.Where(sale => sale.PlatformSaleId == id);
				var query = await Collections.Sales.FindAsync(filter);
				return query.First();
			}
			catch (Exception)
			{
				throw;
			}
        }
    }
}
