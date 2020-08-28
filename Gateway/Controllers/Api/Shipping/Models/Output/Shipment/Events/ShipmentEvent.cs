using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Controllers.Api.Shipping.Models.Output
{
    public class ShipmentEvent
    {
        public string Title { get; set; } = "";

        public string Description { get; set; } = "";

        public string OccurredAt { get; set; } = "";
    }
}
