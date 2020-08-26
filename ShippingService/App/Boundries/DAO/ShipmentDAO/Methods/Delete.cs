using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Boundries.ShipmentDAOMethods
{
    public class Delete : ShipmentDAOMethod
    {
        public async Task Execute(string id)
        {
            var filter = FilterBuilder.Where(shipment => shipment.Id == ObjectId.Parse(id));
            await Collections.Shipments.DeleteOneAsync(filter);
        }
    }
}
