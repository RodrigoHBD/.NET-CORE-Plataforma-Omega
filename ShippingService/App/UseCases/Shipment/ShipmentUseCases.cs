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

        public static DeleteShipment Delete { get { return new DeleteShipment(); } }

        public static ShipmentSet Set { get { return new ShipmentSet(); } }

        public static GetShipment Get { get { return new GetShipment(); } }

        public static async Task UpdateShipmentWithBoundry(Shipment shipment) => 
            await new UpdateShipmentWithBoundry(shipment).Execute();

        public static async Task<bool> GetIsMarketplaceSaleIdRegistered(string id) =>
            await new GetIsMarketplaceSaleIdRegistered(id).Execute();

        public static RunAutoUpdate RunAutoUpdate { get { return new RunAutoUpdate(); } }

        public static SearchShipment Search { get { return new SearchShipment(); } }

        public static async Task NotifyUpdates(Shipment shipment) => 
            await new NotifyUpdates(shipment).Execute();
    }
}
