using ShippingService.App.Models.ShipmentEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Boundries.MailerIntercafe
{
    public class BoundryShipment : IBoundryShipment
    {
        public bool IsPosted { get; set; } = false;

        public bool IsDelivered { get; set; } = false;

        public bool IsAwaitingForPickUp { get; set; } = false;

        public bool IsRejected { get; set; } = false;

        public List<ForwardingEvent> ForwardingEvents { get; set; } = new List<ForwardingEvent>();
    }
}
