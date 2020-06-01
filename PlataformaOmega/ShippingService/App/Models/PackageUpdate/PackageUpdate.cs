using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Models
{
    public class PackageUpdate
    {
        public bool SetPosted { get; set; }
        public bool SetDelivered { get; set; }
        public DateTime UpdateTime { get; set; }
        public PackageUpdate()
        {
            UpdateTime = DateTime.Now;
        }
    }
}
