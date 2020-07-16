using Gateway.Controllers.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Controllers.Shipping.Input
{
    public class PackageSearch
    {
        public string Name { get; set; } = "";
        public string TrackingCode { get; set; } = "";
        public string DynamicString { get; set; } = "";
        public BooleanSearchField BeingTransported { get; set; } = new BooleanSearchField();
        public BooleanSearchField AwaitingForPickUp { get; set; } = new BooleanSearchField();
        public BooleanSearchField Rejected { get; set; } = new BooleanSearchField();
        public BooleanSearchField Delivered { get; set; } = new BooleanSearchField();
        public Pagination Pagination { get; set; } = new Pagination();
    }

    public class Pagination
    {
        public int Offset { get; set; } = 0;
        public int Limit { get; set; } = 0;
    }

   
}
