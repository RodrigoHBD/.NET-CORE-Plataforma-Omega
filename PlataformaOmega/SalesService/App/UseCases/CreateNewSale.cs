using SalesService.App.Factories;
using SalesService.App.Models.Input.RegisterNewSale;
using SalesService.App.Models.Sale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesService.App.UseCases
{
    public class CreateNewSale
    {
        public static Sale Execute(IRegisterNewSaleRequest request)
        {
            try
            {
                return SaleFactory.MakeSale(request);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
