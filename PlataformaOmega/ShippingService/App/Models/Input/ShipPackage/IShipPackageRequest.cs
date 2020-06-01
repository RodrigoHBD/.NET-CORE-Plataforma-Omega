using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Models.Input
{
    public interface IShipPackageRequest
    {
        string Name { get; }
        string ProductId { get; }
        string TrackingCode { get; }
    }
}
