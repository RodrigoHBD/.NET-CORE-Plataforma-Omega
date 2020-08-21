using MongoDB.Driver;
using ShippingService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Boundries.ShipmentDAOMethods
{
    public class Count
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
    }
}
