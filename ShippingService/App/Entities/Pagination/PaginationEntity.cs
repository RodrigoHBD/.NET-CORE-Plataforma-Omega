using ShippingService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Entities
{
    public class PaginationEntity
    {
        public static PaginationIn PaginationInDefault { get; } = new PaginationIn()
        { Limit = 30, Offset = 0 };


    }
}
