using ShippingService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Boundries.ShipmentDAOMethods
{
    public class Register : ShipmentDAOMethod
    {
        public async Task Execute(Shipment shipment)
        {
            await Collections.Shipments.InsertOneAsync(shipment);
        }
    }
}
