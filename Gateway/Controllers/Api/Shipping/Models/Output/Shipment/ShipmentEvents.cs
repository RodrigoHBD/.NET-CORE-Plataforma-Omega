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

        public List<ForwardingEvent> ForwardingEvents { get; set; } = new List<ForwardingEvent>();
    }
}
