using Microsoft.VisualBasic;
using MongoDB.Driver;
using SalesService.App.Models;
using SalesService.App.Models.Input;
using SalesService.App.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesService.App.Boundries.SaleDAOQueries
{
    public class Search
    {
		public async Task<SalesList> Execute(SearchSalesRequest request)
		{
			try
			{
				var filter = BuildFilter(request);
				var offset = request.Pagination.Offset;
				var limit = request.Pagination.Limit;

				var query = Collections.Sales.Find(filter).Skip(offset).Limit(limit);
				return new SalesList()
				{
					Data = query.ToList(),
					Pagination = new PaginationOut()
					{
						Limit = limit,
						Offset = offset,
						Total = await SaleDAO.Queries.Count.Execute(filter)
					}
				};
			}
			catch (Exception)
			{
				throw;
			}
		}

		private FilterDefinition<Sale> BuildFilter(SearchSalesRequest request)
		{
			var platformFilter = BuildPlatformIdFilter(request.PlatformSaleId);

			return Builders<Sale>.Filter.And(platformFilter);
		}

		private FilterDefinition<Sale> BuildPlatformIdFilter(StringSearchFilter filter)
		{
			if (filter.IsActive)
			{
				return Builders<Sale>.Filter.Where(sale => sale.PlatformSaleId == filter.Value);
			}
			else
			{
				return Builders<Sale>.Filter.Empty;
			}
		}
	}
}
