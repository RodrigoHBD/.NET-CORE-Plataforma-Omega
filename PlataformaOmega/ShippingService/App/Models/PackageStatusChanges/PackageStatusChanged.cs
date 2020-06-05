using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Models
{
    public class PackageStatusChangedReport
    {
        public bool AnythingChanged { get; set; } = false;
        public bool DeliveredMustUpdate { get; set; } = false;
        public bool AwaitingForPickUpMustUpdate { get; set; } = false;
        public bool IsRejectedMustUpdate { get; set; } = false;
        public bool PostedMustUpdate { get; set; } = false;
        public bool MessageMustUpdate { get; set; } = false;
    }
}
