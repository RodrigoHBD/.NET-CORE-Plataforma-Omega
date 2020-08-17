using ShippingService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Factories
{
    public class ShipmentFactory
    {
        public static Shipment CreateShipment(string packageId)
        {
            var creator = new ShipmentCreator(packageId);
            return creator.GetShipment();
        }
    }
}
