using ShippingService.App.Entities;
using ShippingService.App.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Models.Input
{
    public class ShipmentSearch
    {
        public BoolSearchFilter AutoUpdate { get; set; } = new BoolSearchFilter();

        public BoolSearchFilter IsPosted { get; set; } = new BoolSearchFilter();

        public BoolSearchFilter IsBeingTransported { get; set; } = new BoolSearchFilter();

        public BoolSearchFilter IsAwaitingForPickUp { get; set; } = new BoolSearchFilter();

        public BoolSearchFilter IsDelivered { get; set; } = new BoolSearchFilter();

        public BoolSearchFilter IsDeliveredToDestination { get; set; } = new BoolSearchFilter();

        public BoolSearchFilter IsRejected { get; set; } = new BoolSearchFilter();

        public StringSearchFilter DynamicString { get; set; } = new StringSearchFilter();

        public StringSearchFilter BoundMarketplace { get; set; } = new StringSearchFilter();

        public PaginationIn Pagination { get; set; } = PaginationEntity.PaginationInDefault;

        public ShipmentSearchSorting Sorting { get; set; } = ShipmentSearchSorting.None;
    }
}
