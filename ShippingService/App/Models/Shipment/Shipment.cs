using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
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

        public string PackageId { get; set; }

        public CreatedEvent CreatedEvent { get; set; } = new CreatedEvent();

        public PostedEvent PostedEvent { get; set; } = new PostedEvent();

        public AwaitingForPickUpEvent AwaitingForPickUpEvent { get; set; } = new AwaitingForPickUpEvent();

        public RejectedEvent RejectedEvent { get; set; } = new RejectedEvent();

        public DeliveredEvent DeliveredEvent { get; set; } = new DeliveredEvent();

        public List<ForwardingEvent> ForwardingEvents { get; set; } = new List<ForwardingEvent>();

        // public methods

        // private properties
        private Package Package { get; set; }
        private bool PackageIsCached { get; set; } = false;

        // private methods
        private async Task CachePackage()
        {
            Package = await UseCases.GetPackage.Execute(PackageId);
        }

        // constructor
        public Shipment()
        {
            ForwardingEvents = new List<ForwardingEvent>();
        }
    }

}
