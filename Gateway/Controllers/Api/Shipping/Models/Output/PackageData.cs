using Gateway.Controllers.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Controllers.Api.Shipping.Models.Output
{
    public class PackageData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SaleId { get; set; }
        public string MarketplaceSaleId { get; set; } 
        public string MarketplaceAccountId { get; set; }
        public string TrackingCode { get; set; }
        public string BoundPlatform { get; set; }
        public double Weight { get; set; }
        public bool IsWatched { get; set; }
        public bool IsManuallyCreated { get; set; }
        public List<string> Content { get; set; }
        public PackageStatus Status { get; set; } = new PackageStatus();
        public PackageMessages Messages { get; set; } = new PackageMessages();
        public PackageLocations Locations { get; set; } = new PackageLocations();
        public PackageDates Dates { get; set; } = new PackageDates();
    }

    public class PackageStatus
    {
        public bool IsPosted { get; set; }
        public bool IsDelivered { get; set; }
        public bool IsAwaitingForPickUp { get; set; }
        public bool IsRejected { get; set; }
        public bool IsBeingTransported { get; set; }
    }

    public class PackageDates
    {
        public string CreatedAt { get; set; }
        public string PostedAt { get; set; }
        public string LastModifiedAt { get; set; }
    }

    public class PackageMessages
    {
        public string StatusDescription { get; set; }
    }

    public class PackageLocations
    {
        public Location CurrentLocation { get; set; } = new Location();
        public Location HeadedToLocation { get; set; } = new Location();
    }
}
