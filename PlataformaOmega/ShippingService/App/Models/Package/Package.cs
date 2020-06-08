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
        public string Name { get; set; }
        public string ProductId { get; set; }
        public string SaleId { get; set; }
        public string TrackingCode { get; set; }
        public PackageDates Dates { get; set; }
        public PackageStatus Status { get; set; }
        public PackageStatusMessages Messages { get; set; }
        public PackageLocation Location { get; set; }
        public bool IsSoftDeleted { get; set; }

        public Package()
        {
            Dates = new PackageDates();
            Status = new PackageStatus();
            Location = new PackageLocation();
            IsSoftDeleted = false;
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
        public Location HeadedTo { get; set; } = LocationEntity.ExportInstanceOfDefaultLocation();
        public Location CommingFrom { get; set; } = LocationEntity.ExportInstanceOfDefaultLocation();
        public Location CurrentLocation { get; set; } = LocationEntity.ExportInstanceOfDefaultLocation();
        public Location ShippedFrom { get; set; } = LocationEntity.ExportInstanceOfDefaultLocation();
    }
}
