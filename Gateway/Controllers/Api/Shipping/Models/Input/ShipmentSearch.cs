using Gateway.Controllers.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Controllers.Shipping.Input
{
    public class ShipmentSearch
    {
        public StringSearchFilter DynamicString { get; set; } = new StringSearchFilter();

        public BooleanSearchFilter BeingTransported { get; set; } = new BooleanSearchFilter();

        public BooleanSearchFilter AwaitingForPickUp { get; set; } = new BooleanSearchFilter();

        public BooleanSearchFilter Rejected { get; set; } = new BooleanSearchFilter();

        public BooleanSearchFilter Delivered { get; set; } = new BooleanSearchFilter();

        public BooleanSearchFilter DeliveredToDestination { get; set; } = new BooleanSearchFilter();

        public BooleanSearchFilter Posted { get; set; } = new BooleanSearchFilter();

        public PaginationIn Pagination { get; set; } = new PaginationIn();
    }   
}
