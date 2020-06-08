using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Models.Input
{
    public interface IPackageUpdateRequest
    {
        string Id { get; }
        bool SetPosted { get; }
        bool SetDelivered { get; }
        string StatusMessage { get; }
        DateTime PostedDate { get; }
        DateTime DeliveredDate { get; }
        Location HeadedTo { get; set; }
    }


}
