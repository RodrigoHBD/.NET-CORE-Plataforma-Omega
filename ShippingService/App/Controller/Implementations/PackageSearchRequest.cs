using ShippingService.App.Models.Input;
using ShippingService.App.Models.Input.SearchDataFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Controller.Implementations
{
    public class PackageSearchRequest : IPackageSearchRequest
    {
        public IStringSearchField Name { get; set; } = new StringSearchField();
        public IStringSearchField TrackingCode { get; set; } = new StringSearchField();
        public IStringSearchField DynamicString { get; set; } = new StringSearchField();
        public IPaginationIn Pagination { get; set; } = new PaginationIn();
    }

    public class StringSearchField : IStringSearchField
    {
        public bool IsActive { get; set; } = false;

        public string Value { get; set; } = "";
    }
}
