using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Models
{
    public class PackageStatusChangesReport
    {
        public bool AnythingChanged { get; set; } = false;
        public bool DeliveredMustUpdate { get; set; } = false;
        public bool AwaitingForPickUpMustUpdate { get; set; } = false;
        public bool IsRejectedMustUpdate { get; set; } = false;
        public bool PostedMustUpdate { get; set; } = false;
        public bool MessageMustUpdate { get; set; } = false;
        public bool IsBeingTransportedMustUpdate { get; set; }
        public bool HasArrived { get; set; }
    }
}
