using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Models
{
    public class PackageDates
    {
        public DateTime LastModifiedAt { get; set; } = new DateTime();

        public DateTime CreatedAt { get; private set; } = new DateTime();
    }
}
