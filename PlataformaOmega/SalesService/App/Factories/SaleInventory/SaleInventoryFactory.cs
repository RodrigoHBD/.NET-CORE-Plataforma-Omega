﻿using SalesService.App.Models.Input;
using SalesService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;

namespace SalesService.App.Factories
{
    public class SaleInventoryFactory
    {
        public static SaleInventory MakeInventory(IRegisterNewSaleRequest request)
        {
            try
            {
                var config = request.TotalValueCalculationConfig;
                var saleInventory = new SaleInventory()
                {
                    ProductId = request.ProductId
                };

                if (config.OverrideUnitaryPrice)
                {
                    saleInventory.UnitaryPrice = request.TotalValueCalculationConfig.UnitaryPrice;
                }
                SetSaleInventoryStates(request, saleInventory);

                return saleInventory;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static void SetSaleInventoryStates(IRegisterNewSaleRequest request, SaleInventory inventory)
        {
            try
            {
                if (request.TotalValueCalculationConfig.OverrideUnitaryPrice)
                {
                    inventory.States.UnitaryPriceWasOverridden = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}
