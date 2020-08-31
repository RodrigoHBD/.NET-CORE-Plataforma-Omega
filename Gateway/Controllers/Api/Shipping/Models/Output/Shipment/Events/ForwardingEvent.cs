using Gateway.Controllers.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Controllers.Api.Shipping.Models.Output
{
    public class ForwardingEvent : ShipmentEvent
    {
        public bool PackageHasArrived { get; set; }

        public string BoundryMessage { get; set; } = "";

        public string ArrivedAt { get; set; } = "";

        public Location ForwardedFrom { get; set; } = new Location();

        public Location ForwardedTo { get; set; } = new Location();
    }
}
