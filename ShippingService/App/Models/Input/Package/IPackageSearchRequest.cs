using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Models.Input
{
    public class SearchPackageRequest
    {
        public StringSearchField Name { get; set; }
        public StringSearchField TrackingCode { get; set; }
        public StringSearchField DynamicString { get; }
        public BoolSearchField AwaitingForPickUp { get; set; }
        public BoolSearchField Rejected { get; set; }
        public BoolSearchField Delivered { get; set; }
        public BoolSearchField BeingTransported { get; set; }
        public BoolSearchField Posted { get; set; }
        public PaginationIn Pagination { get; }
    }
}
