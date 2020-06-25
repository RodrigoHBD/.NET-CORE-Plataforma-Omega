using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Models
{
    public class PackageChangesReport
    {
        public PackageStatusChangesReport Status { get; set; } = new PackageStatusChangesReport();
        public PackageMessagesChangesReport Messages { get; set; } = new PackageMessagesChangesReport();
        public PackageLocationChangesReport Locations { get; set; } = new PackageLocationChangesReport();
    }
}
