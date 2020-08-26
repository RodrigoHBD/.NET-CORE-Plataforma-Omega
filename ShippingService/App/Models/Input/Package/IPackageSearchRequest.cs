using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Models.Input
{
    public class SearchPackageRequest
    {
        public StringSearchFilter Name { get; set; }
        public StringSearchFilter TrackingCode { get; set; }
        public StringSearchFilter DynamicString { get; }
        public BoolSearchFilter AwaitingForPickUp { get; set; }
        public BoolSearchFilter Rejected { get; set; }
        public BoolSearchFilter Delivered { get; set; }
        public BoolSearchFilter BeingTransported { get; set; }
        public BoolSearchFilter Posted { get; set; }
        public PaginationIn Pagination { get; }
    }
}
