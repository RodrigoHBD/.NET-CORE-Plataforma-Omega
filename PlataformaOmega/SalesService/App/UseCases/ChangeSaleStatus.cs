using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesService.App.Models.Sale;

namespace SalesService.App.UseCases
{
    public class ChangeSaleStatus
    {
        public static async Task<Sale> Execute(Sale sale, SaleStatus newStatus)
        {
            try
            {
                sale.Status = newStatus;
                return sale;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
