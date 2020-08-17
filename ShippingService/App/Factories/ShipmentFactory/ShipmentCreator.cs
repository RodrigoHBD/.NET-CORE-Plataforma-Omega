using ShippingService.App.Models;
using ShippingService.App.Models.ShipmentEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Factories
{
    public class ShipmentCreator
    {
        public Shipment GetShipment()
        {
            return new Shipment()
            {
                PackageId = PackageId,
                CreatedEvent = GetCreatedEvent()
            };
        }

        public ShipmentCreator(string packageId)
        {
            PackageId = packageId;
        }

        private string PackageId { get; set; }

        private CreatedEvent GetCreatedEvent()
        {
            var _event = new CreatedEvent();
            _event.SetOccuredAtToNow();
            return _event;
        }
    }
}
