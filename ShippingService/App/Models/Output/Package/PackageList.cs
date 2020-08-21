using System.Collections.Generic;

namespace ShippingService.App.Models.Output
{
    public class PackageList
    {
        public List<Package> Data { get; set; }

        public PaginationOut Pagination { get; set; }
    }
}
