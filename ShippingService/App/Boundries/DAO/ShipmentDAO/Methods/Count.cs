using MongoDB.Driver;
using ShippingService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Boundries.ShipmentDAOMethods
{
    public class Count : ShipmentDAOMethod
    {
        public async Task<long> UsingFilter(FilterDefinition<Shipment> filter)
        {
            try
            {
                return await Collections.Shipments.CountDocumentsAsync(filter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<long> MarketplaceSaleId(string id)
        {
            try
            {
                var filter = FilterBuilder.Where(shipment => shipment.MarketplaceData.SaleId == id);
                return await Collections.Shipments.CountDocumentsAsync(filter);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
