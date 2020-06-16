using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShippingService.App.Models.Input.SearchDataFields;

namespace ShippingService.App.Models.Input
{
    public interface IPackageSearchRequest
    {
        IStringSearchField Name { get; }
        IStringSearchField TrackingCode { get; }
        IPaginationIn Pagination { get; }
    }
}
