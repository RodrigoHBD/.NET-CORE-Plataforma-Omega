﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Controllers.Api.Shipping.Models.Output
{
    public class RejectedEvent : ShipmentEvent
    {
        public bool IsRejected { get; set; }
    }
}
