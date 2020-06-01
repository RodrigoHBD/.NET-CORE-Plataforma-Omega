using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Models.Input
{
    public interface IPackageUpdateRequest
    {
        public bool SetPosted { get; }
        public bool SetDelivered { get; }
        public DateTime PostedDate { get; }
        public DateTime DeliveredDate { get; }
    }
}
