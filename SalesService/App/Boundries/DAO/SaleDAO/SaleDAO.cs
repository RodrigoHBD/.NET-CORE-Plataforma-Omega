using Microsoft.VisualBasic;
using SalesService.App.Boundries.SaleDAOQueries;
using SalesService.App.Models;
using SalesService.App.Models.Input;
using SalesService.App.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesService.App.Boundries
{
    public class SaleDAO
    {
		public static Queries Queries { get; private set; } = new Queries();

        public async Task<string> RegisterNew(Sale sale)
        {
			try
			{
				return await Queries.Register.Execute(sale);
			}
			catch (Exception)
			{
				throw;
			}
        }

		public async Task<SalesList> SearchSales(SearchSalesRequest request)
		{
			try
			{
				return await Queries.Search.Execute(request);
			}
			catch (Exception)
			{
				throw;
			}
		}

	}
}
