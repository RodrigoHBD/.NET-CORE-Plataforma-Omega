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
        IStringSearchField DynamicString { get; }
        IBooleanSearchField AwaitingForPickUp { get; set; }
        IBooleanSearchField Rejected { get; set; }
        IBooleanSearchField Delivered { get; set; }
        IBooleanSearchField BeingTransported { get; set; }
        IBooleanSearchField Posted { get; set; }
        IPaginationIn Pagination { get; }
    }
}
