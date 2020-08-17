using ShippingService.App.Models.ShipmentEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Boundries.MailerIntercafe
{
    public interface IBoundryShipment
    {
        bool IsPosted { get; }
        bool IsDelivered { get; }
        bool IsAwaitingForPickUp { get; }
        bool IsRejected { get; }
        List<ForwardingEvent> ForwardingEvents { get; }
    }
}
