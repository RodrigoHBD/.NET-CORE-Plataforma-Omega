using SalesService.App.Models.Input.RegisterNewSale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesService.App.UseCases
{
    public class UseCaseOperator
    {
        public static async Task RegisterNewSale(IRegisterNewSaleRequest request)
        {
            try
            {
                var sale = CreateNewSale.Execute(request);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
