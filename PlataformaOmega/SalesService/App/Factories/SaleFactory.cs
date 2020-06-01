using SalesService.App.Models.Input.RegisterNewSale;
using SalesService.App.Models.Sale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesService.App.Factories
{
    public class SaleFactory
    {
        public static Sale MakeSale(IRegisterNewSaleRequest request)
        {
            try
            {
                return new Sale()
                {
                    ProductId = request.ProductId,
                    Plataform = request.Plataform,
                    Inventory = new SaleInventory()
                    {
                        TotalValue = request.TotalValue,
                        QuantitySold = request.QuantitySold
                    }
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
