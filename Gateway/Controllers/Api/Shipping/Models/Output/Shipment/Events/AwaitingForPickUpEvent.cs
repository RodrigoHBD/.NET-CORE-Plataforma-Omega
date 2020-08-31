using Gateway.Controllers.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Controllers.Api.Shipping.Models.Output
{
    public class AwaitingForPickUpEvent : ShipmentEvent
    {
        public bool IsSet { get; set; }

        public Location Location { get; set; }
    }
}
