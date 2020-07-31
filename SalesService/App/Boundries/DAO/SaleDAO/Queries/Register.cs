using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesService.App.Models;

namespace SalesService.App.Boundries.SaleDAOQueries
{
    public class Register
    {
		public async Task<string> Execute(Sale sale)
		{
			try
			{
				await Collections.Sales.InsertOneAsync(sale);
				return sale.Id.ToString();
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
