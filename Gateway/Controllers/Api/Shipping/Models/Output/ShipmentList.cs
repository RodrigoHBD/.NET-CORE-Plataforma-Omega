using Gateway.Controllers.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Controllers.Api.Shipping.Models
{
    public class ShipmentList
    {
        public PaginationOut Pagination { get; set; } = new PaginationOut();

        public List<Shipment> Data { get; set; } = new List<Shipment>();
    }
}
