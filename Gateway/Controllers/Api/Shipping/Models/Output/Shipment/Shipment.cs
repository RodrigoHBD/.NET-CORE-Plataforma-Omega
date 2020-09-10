using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Controllers.Api.Shipping.Models
{
    public class Shipment
    {
        public string Id { get; set; }

        public string PackageId { get; set; }

        public string BoundMarketplace { get; set; }

        public string BoundryMessage { get; set; } = "";

        public string TrackingCode { get; set; }

        public string MarketplaceAccountId { get; set; }

        public string MarketplaceSaleId { get; set; }

        public string ShippingService { get; set; }

        public string CreatedAt { get; set; } 

        public bool AutoUpdate { get; set; }

        public bool CreatedManually { get; set; }

        public ShipmentStates States { get; set; } = new ShipmentStates();
    }

    public class ShipmentStates
    {
        public bool IsPosted { get; set; }

        public bool IsBeingTransported { get; set; }

        public bool IsAwaitingForPickUp { get; set; }

        public bool IsRejected { get; set; }

        public bool IsDelivered { get; set; }

        public bool IsDeliveredToDestination { get; set; }
    }
}
