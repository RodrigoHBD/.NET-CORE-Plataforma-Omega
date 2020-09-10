using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ShippingService.App.Boundries;
using ShippingService.App.Models;
using ShippingService.App.Models.ShipmentEvents;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Models
{
    public class Shipment
    {
        // public properties
        [BsonId]
        public ObjectId Id { get; set; }

        public string PackageId { get; set; } = "";

        public string TrackingCode { get; set; } = "";

        public string BoundryMessage { get; set; } = "";

        public bool AutoUpdate { get; set; } = false;

        public bool CreatedManually { get; set; } = false;

        public ShippingBoundry.Implementation BoundryImplementation { get; set; } = ShippingBoundry.Implementation.Unset;

        public ShipmentMarketplaceData MarketplaceData { get; set; } = new ShipmentMarketplaceData();

        public CreatedEvent CreatedEvent { get; set; } = new CreatedEvent();

        public PostedEvent PostedEvent { get; set; } = new PostedEvent();

        public AwaitingForPickUpEvent AwaitingForPickUpEvent { get; set; } = new AwaitingForPickUpEvent();

        public RejectedEvent RejectedEvent { get; set; } = new RejectedEvent();

        public DeliveredEvent DeliveredEvent { get; set; } = new DeliveredEvent();

        public List<ForwardingEvent> ForwardingEvents { get; set; } = new List<ForwardingEvent>();

        public Shipment()
        {
            
        }

        private Package Package { get; set; }

        private bool PackageIsCached { get; set; } = false;

        private async Task CachePackage()
        {
            Package = await UseCases.GetPackage.Execute(PackageId);
        }

    }

}
