using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Models
{
    public class PackageLocationChangesReport
    {
        public bool AnythingChanged { get; set; } = false;
        public bool CommingFromLocationMustUpdate { get; set; } = false;
        public bool HeadedToLocationMustUpdate { get; set; } = false;
        public bool CurrentLocationMustUpdate { get; set; } = false;
    }
}
