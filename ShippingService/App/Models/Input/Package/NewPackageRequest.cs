using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Models.Input
{
    public class NewPackageRequest
    {
        public string Name { get; set; }

        public int WeightInGrams { get; set; }

        public int WidthInMm { get; set; }

        public int LengthInMm { get; set; }

        public int HeightInMm { get; set; }

        public List<string> ContentIds { get; set; }
    }
}
