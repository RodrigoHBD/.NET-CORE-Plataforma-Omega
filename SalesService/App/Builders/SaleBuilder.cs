using SalesService.App.Models.Input;
using SalesService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesService.App.Factories;

namespace SalesService.App.Builders
{
    public class SaleBuilder
    {
        public static Sale BuildSale(IRegisterNewSaleRequest request)
        {
            try
            {
                var config = request.TotalValueCalculationConfig;
                var sale = new Sale()
                {
                    Status = request.Status,
                    Plataform = request.Plataform,
                    Inventory = BuildInventory(request)
                };

                request.IncludedServices.ForEach(
                    service => sale.Inventory.IncludedServices.Add( BuildIncludedService(service)) );

                return sale;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static SaleIncludedService BuildIncludedService(IIncludedService service)
        {
            try
            {
                return SaleIncludedServiceFactory.MakeIncludedService(service);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static SaleInventory BuildInventory(IRegisterNewSaleRequest request)
        {
            try
            {
                return SaleInventoryFactory.MakeInventory(request);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
