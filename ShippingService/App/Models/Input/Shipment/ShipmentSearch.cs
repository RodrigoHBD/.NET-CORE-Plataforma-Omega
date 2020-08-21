using ShippingService.App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Models.ShipmentSearch
{
    public class ShipmentSearch
    {
        public BoolSearchField IsPosted { get; set; }

        public BoolSearchField IsBeingTransported { get; set; }

        public BoolSearchField IsAwaitingForPickUp { get; set; }

        public BoolSearchField IsDelivered { get; set; }

        public BoolSearchField IsRejected { get; set; }

        public StringSearchField DynamicString { get; set; }

        public StringSearchField BoundMarketplace { get; set; }

        public PaginationIn Pagination { get; set; } = PaginationEntity.PaginationInDefault;
    }
}
