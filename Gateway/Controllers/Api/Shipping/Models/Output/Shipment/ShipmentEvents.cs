using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Controllers.Api.Shipping.Models.Output
{
    public class ShipmentEvents
    {
        public CreatedEvent CreatedEvent { get; set; } = new CreatedEvent();

        public PostedEvent PostedEvent { get; set; } = new PostedEvent();

        public AwaitingForPickUpEvent AwaitingForPickUpEvent { get; set; } = new AwaitingForPickUpEvent();

        public RejectedEvent RejectedEvent { get; set; } = new RejectedEvent();

        public DeliveredEvent DeliveredEvent { get; set; } = new DeliveredEvent();

        public List<ForwardingEvent> ForwardingEvents { get; set; } = new List<ForwardingEvent>();
    }
}
