using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Models.MailerService.PackageData
{
    public class MailerServicePackageData
    {
        public PackageStatus Status { get; set; } = new PackageStatus();
        public PackageLocation Location { get; set; } = new PackageLocation();
    }
}
