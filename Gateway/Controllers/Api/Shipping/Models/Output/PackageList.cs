using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Controllers.Api.Shipping.Models.Output
{
    public class PackageList
    {
        public List<PackageData> Data { get; set; } = new List<PackageData>();
        public Pagination Pagination { get; set; } = new Pagination();
    }

    public class Pagination
    {
        public int Offset { get; set; }
        public int Limit { get; set; }
        public long Total { get; set; }
    }
}
