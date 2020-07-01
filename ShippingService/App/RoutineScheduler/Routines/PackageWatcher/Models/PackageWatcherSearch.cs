using ShippingService.App.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.RoutineSchedulerRoutines.PackageWatcher
{
    public class PackageWatcherSearch : IPackageWatcherSearch
    {
        public string PackageId { get; set; }

        public string TrackingCode { get; set; }

        public IPaginationIn Pagination { get; set; }

        public PackageWatcherSearch()
        {
            PackageId = "";
            TrackingCode = "";
            Pagination = new PaginationIn();
        }
    }

    public class PaginationIn : IPaginationIn
    {
        public int Offset { get; set; } = 0;
        public int Limit { get; set; } = PackageWatcherRoutine.DefaultSearchLimit;
    }
}
