using ShippingService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Models.Output
{
    public class ShipmentList
    {
        public List<Shipment> Data { get; set; }

        public PaginationOut Pagination { get; set; }
    }
}
