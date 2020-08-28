using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Controllers.Api.Shipping.Models.Output
{
    public class ForwardingEvent : ShipmentEvent
    {
        public bool PackageHasArrived { get; set; }
    }
}
