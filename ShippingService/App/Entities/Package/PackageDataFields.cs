using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Entities.PackageDataField
{
    public class PackageDataFields
    {
        public TrackingCode TrackingCode { get; } = new TrackingCode();
        public MarketplaceSaleId MarketplaceSaleId { get; } = new MarketplaceSaleId();
    }
}
