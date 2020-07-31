using SalesService.App.Models;
using SalesService.App.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesService.App.Factories
{
    public class SaleFactory
    {
        public static Sale Make(RegisterSaleRequest request)
        {
            var sale = new Sale()
            {
                Plataform = request.Plataform,
                PlatformSaleId = request.PlatformSaleId,
                Status = SaleStatus.Pending,
                Inventory = SaleInventoryFactory.MakeInventory(request)
            };

            return sale;
        }
    }
}
