using MongoDB.Bson;
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
        public async Task<bool> IdBool(string id)
        {
            try
            {
                var filter = FilterBuilder.Where(shipment => shipment.Id == ObjectId.Parse(id));
                var result = await Collections.Shipments.FindAsync<Shipment>(filter);
                return result.ToList().Count > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Shipment> PackageId(string id)
        {
            var filter = FilterBuilder.Where(shipment => shipment.PackageId == id);
            var result = await Collections.Shipments.FindAsync<Shipment>(filter);
            return result.First();
        }
    }
}
