using ShippingService.App.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Boundries.DAOReturnModels
{
    public class PaginationOut : IPaginationOut
    {
        public int Offset { get; set; }

        public int Limit { get; set; }

        public int Total { get; set; }
    }
}
