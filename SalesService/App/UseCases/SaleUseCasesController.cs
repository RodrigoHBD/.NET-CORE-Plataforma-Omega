using SalesService.App.Entities;
using SalesService.App.Models.Input;
using SalesService.App.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesService.App.UseCases
{
    public class SaleUseCasesController
    {
        public static async Task<string> RegisterNewSaleAsync(RegisterSaleRequest request)
        {
			try
			{
				var sale = SaleUseCases.CreateNewSale.Execute(request);
				await SaleEntity.ValidateNewSale(sale);
				await SaleUseCases.RegisterSale.Execute(sale);
				return sale.Id.ToString();
			}
			catch (Exception)
			{
				throw;
			}
        }

		public static async Task<SalesList> SearchSales(SearchSalesRequest request)
		{
			try
			{
				SaleSearchEntity.ValidateSearchRequest(request);
				return await SaleUseCases.SearchSales.Execute(request);
			}
			catch (Exception)
			{
				throw;
			}
		}

    }
}
