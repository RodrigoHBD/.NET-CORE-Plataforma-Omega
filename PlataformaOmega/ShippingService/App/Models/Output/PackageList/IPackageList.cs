using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Models.Output
{
    public interface IPackageList
    {
        List<Package> Packages { get; }
        IPaginationOut Pagination { get; }
    }
}
