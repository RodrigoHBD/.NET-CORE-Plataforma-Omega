using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesService.App.CustomExceptions;
using SalesService.App.Models;

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
                    throw new ValidationException("Quantidade vendida mão pode ser zero", "");
                }
                if (!saleTotalValueIsGreaterThanZero)
                {
                    //throw new Exception("Nao foi possivel determinar o valor total da venda");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
