using ShippingService.App.Boundries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Models.Input
{
    public class NewShipmentRequest
    {
        public string TrackingCode { get; set; }

        public string BoundMarketplace { get; set; }

        public string MarketplaceAccountId { get; set; }

        public string MarketplaceSaleId { get; set; }

        public bool SetAutoUpdate { get; set; }

        public bool SetManuallyCreated { get; set; }

        public ShippingBoundry.Implementation ShippingImplementation { get; set; }

        public NewPackageRequest PackageData { get; set; } = new NewPackageRequest();
    }
}
