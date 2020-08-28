using Gateway.Controllers.Api.Shipping.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Controllers.Api.Shipping.Models.Input
{
    public class NewShipment
    {
        public string TrackingCode { get; set; } = "";

        public string BoundMarketplace { get; set; } = "";

        public string MarketpalceAccountId { get; set; } = "";

        public string MarketpalceSaleId { get; set; } = "";

        public string ShippingService { get; set; } = "";

        public bool SetAutoUpdate { get; set; } = false;

        public bool SetCreatedManually { get; set; } = false;

        public PackageData Package { get; set; } = new PackageData();
    }

    public class PackageData
    {
        public string Name { get; set; } = "";

        public int WeightInGrams { get; set; } 

        public int WidthInMm { get; set; }

        public int LengthInMm { get; set; }

        public int HeightInMm { get; set; }

        public List<string> Content { get; set; } = new List<string>();
    }
}
