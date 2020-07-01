using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Models.Input
{
    public interface IPackageWatcherSearch
    {
        string PackageId { get; }
        string TrackingCode { get; }
        IPaginationIn Pagination { get; }
    }
}
