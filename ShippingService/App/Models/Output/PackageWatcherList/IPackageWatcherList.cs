using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Models.Output
{
    public interface IPackageWatcherList
    {
        List<PackageWatcher> Watchers { get; }
        IPaginationOut Pagination { get; }
    }
}
