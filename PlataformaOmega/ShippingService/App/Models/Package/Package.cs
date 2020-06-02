using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
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
        public bool IsSoftDeleted { get; set; }
        public Package()
        {
            Dates = new PackageDates();
            Status = new PackageStatus();
            IsSoftDeleted = false;
        }
    }

    public class PackageStatus
    {
        public bool HasBeenDelivered { get; set; }
        public bool HasBeenPosted { get; set; }
        public string Message { get; set; }
        public PackageStatus()
        {
            HasBeenDelivered = false;
            HasBeenPosted = false;
        }
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
}
