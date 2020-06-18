using Gateway.Controllers.Api.Shipping.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Controllers.Api.Shipping.Models.Input
{
    public class NewPackage
    {
        public string Name { get; set; } = "";
        public string SaleId { get; set; } = "";
        public string TrackingCode { get; set; } = "";
        public double Weight { get; set; } = 0;
        public int Platform { get; set; } = -1;
        public bool SetWatcher { get; set; } = false;
        public List<string> Content { get; set; } = new List<string>();
        public Location PostingLocation { get; set; } = new Location();
    }
}
