using ShippingService.App.Models;
using ShippingService.App.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Boundries.DAOReturnModels
{
    public class PackageWatcherList : IPackageWatcherList
    {
        public List<PackageWatcher> Watchers { get; set; }

        public IPaginationOut Pagination { get; set; }
    }
}
