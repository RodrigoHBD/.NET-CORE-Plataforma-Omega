using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Models.Input
{
    public interface IShipPackageRequest
    {
        string Name { get; }
        string SaleId { get; }
        string TrackingCode { get; }
        double Weight { get; }
        AvailablePlatformsToBind Platform { get; }
        List<string> Content { get; }
        Location PackageInitialLocation { get; }
        bool SetWatcher { get; }
        bool CreatedManually { get; }
    }
}
