using SalesService.App.Factories;
using SalesService.App.Models.Input;
using SalesService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesService.App.UseCases
{
    public class CreateNewSale
    {
        public Sale Execute(RegisterSaleRequest request)
        {
            try
            {
                return SaleFactory.Make(request);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
