
using ShippingService.App.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Controller.Implementations
{
    public class PaginationIn : IPaginationIn
    {
        public int Offset { get; set; } = 0;

        public int Limit { get; set; } = 0;
    }
}
