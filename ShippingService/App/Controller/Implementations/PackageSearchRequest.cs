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
        public IBooleanSearchField AwaitingForPickUp { get; set; } = new BooleanSearchField();
        public IBooleanSearchField Rejected { get; set; } = new BooleanSearchField();
        public IBooleanSearchField Delivered { get; set; } = new BooleanSearchField();
        public IBooleanSearchField BeingTransported { get; set; } = new BooleanSearchField();
    }

    public class StringSearchField : IStringSearchField
    {
        public bool IsActive { get; set; } = false;

        public string Value { get; set; } = "";
    }

    public class BooleanSearchField : IBooleanSearchField
    {
        public bool IsActive { get; set; } = false;

        public bool Value { get; set; } = false;
    }
}
