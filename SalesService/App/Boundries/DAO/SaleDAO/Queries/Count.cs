using Microsoft.VisualBasic;
using MongoDB.Driver;
using SalesService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesService.App.Boundries.SaleDAOQueries
{
    public class Count
    {
        public async Task<long> Execute(FilterDefinition<Sale> filter)
        {
			try
			{
				return await Collections.Sales.CountDocumentsAsync(filter);
			}
			catch (Exception)
			{
				throw;
			}
        }
    }
}
