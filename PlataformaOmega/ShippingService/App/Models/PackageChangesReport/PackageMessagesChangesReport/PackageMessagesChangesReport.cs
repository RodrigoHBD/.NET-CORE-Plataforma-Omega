using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Models
{
    public class PackageMessagesChangesReport
    {
        public bool StatusDescriptionMustUpdate { get; set; } = false;
        public bool RejectionReasonMustUpdate { get; set; } = false;
    }
}
