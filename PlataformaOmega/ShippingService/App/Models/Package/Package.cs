using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ShippingService.App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Models
{
    public class Package
    {
        [BsonId]
        public ObjectId Id { get; set; } 
        public string Name { get; set; } = "";
        public string SaleId { get; set; } = "";
        public string TrackingCode { get; set; } = "";
        public AvailablePlatformsToBind BoundPlatform { get; set; } 
        public double Weight { get; set; }
        public PackageContent Content { get; set; }
        public PackageDates Dates { get; set; }
        public PackageStatus Status { get; set; }
        public PackageStatusMessages Messages { get; set; }
        public PackageLocation Location { get; set; }
        public bool IsSoftDeleted { get; set; } = false;
        public bool IsBeingWatched { get; set; } = false;

        public Package()
        {
            Dates = new PackageDates();
            Status = new PackageStatus();
            Location = new PackageLocation();
            Messages = new PackageStatusMessages();
            IsSoftDeleted = false;
            BoundPlatform = AvailablePlatformsToBind.None;
        }
    }

    public class PackageStatus
    {
        public bool HasBeenDelivered { get; set; } = false;
        public bool HasBeenPosted { get; set; } = false;
        public bool IsAwaitingForPickUp { get; set; } = false;
        public bool IsRejected { get; set; } = false;
        public bool IsBeingTransported { get; set; } = false;
        public string Message { get; set; } = "";
    }

    public class PackageDates
    {
        public DateTime PostedAt { get; set; }
        public DateTime DeliveredAt { get; set; }
        public DateTime LastUpdated { get; set; }
        public PackageDates()
        {
            PostedAt = DateTime.UtcNow;
            DeliveredAt = DateTime.UtcNow;
            LastUpdated = DateTime.UtcNow;
        }
    }

    public class PackageStatusMessages
    {
        public string StatusDescription { get; set; } = "";
        public string RejectionReason { get; set; } = "";
    }

    public class PackageLocation
    {
        public Location HeadedTo { get; set; } = new Location();
        public Location CommingFrom { get; set; } = new Location();
        public Location CurrentLocation { get; set; } = new Location();
        public Location ShippedFrom { get; set; } = new Location();
        public Location FinalDestination { get; set; } = new Location();
    }

    public class PackageContent
    {
        public List<string> Products { get; set; }
    }

    public enum AvailablePlatformsToBind
    {
        MercadoLivre = 0,
        B2W = 1,
        None = 10
    }
}
