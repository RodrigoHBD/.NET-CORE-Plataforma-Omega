using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Controllers.Shipping.Input
{
    public class PackageSearch
    {
        public string Name { get; set; }
        public Pagination Pagination { get; set; }
    }

    public class Pagination
    {
        public int Offset { get; set; }
        public int Limit { get; set; }
    }
}
