using SalesService.App.Boundries;
using SalesService.App.Models.Input;
using SalesService.App.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesService.App.UseCases
{
    public class SearchSales
    {
        public async Task<SalesList> Execute(SearchSalesRequest request)
        {
			try
			{
				return await SaleDAO.Queries.Search.Execute(request);
			}
			catch (Exception)
			{
				throw;
			}
        }
    }
}
