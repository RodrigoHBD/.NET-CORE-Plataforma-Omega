using MongoDB.Driver;
using ShippingService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Boundries.ShipmentDAOMethods
{
    public class GetBy : ShipmentDAOMethod
    {
        public async Task<Shipment> PackageId(string id)
        {
            var filter = FilterBuilder.Where(shipment => shipment.PackageId == id);
            var result = await Collections.Shipments.FindAsync<Shipment>(filter);
            return result.First();
        }
    }
}
