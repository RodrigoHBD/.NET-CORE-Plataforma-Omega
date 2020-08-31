using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Controllers.Api.Shipping.Models.Output
{
    public class DeliveredEvent : ShipmentEvent
    {
        public bool IsDelivered { get; set; }

        public bool IsDeliveredToDestination { get; set; }
    }
}
