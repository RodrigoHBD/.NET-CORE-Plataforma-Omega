using ShippingService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.UseCases
{
    public class ShipmentUseCases
    {
        public static RegisterShipment RegisterShipment { get { return new RegisterShipment(); } }
        public static ShipmentSet Set { get { return new ShipmentSet(); } }
        public static ShipmentGetBy Get { get { return new ShipmentGetBy(); } }
        public static async Task UpdateShipmentWithBoundry(Shipment shipment) => 
            await new UpdateShipmentWithBoundry(shipment).Execute();
    }
}
