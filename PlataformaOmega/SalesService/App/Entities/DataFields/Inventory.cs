using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesService.App.CustomExceptions;
using SalesService.App.Models.Sale;

namespace SalesService.App.Entities.SaleDataFields
{
    public class Inventory
    {
        public static void Validate(SaleInventory inventory)
        {
            try
            {
                var quantitySoldIsGreaterThanZero = inventory.QuantitySold > 0;
                var saleTotalValueIsGreaterThanZero = inventory.TotalValue > 0;

                if (!quantitySoldIsGreaterThanZero)
                {
                    throw new ValidationException("Quantidade vendidap", "");
                }
                if (!saleTotalValueIsGreaterThanZero)
                {
                    throw new ValidationException("", "");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
