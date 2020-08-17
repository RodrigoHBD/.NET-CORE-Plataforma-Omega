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
        public string MarketplaceSaleId { get; set; } = "";
        public string MarketplaceAccountId { get; set; } = "";
        public string TrackingCode { get; set; } = "";
        public AvailablePlatformsToBind BoundPlatform { get; set; } 
        public double Weight { get; set; }
        public PackageContent Content { get; set; }
        public PackageDates Dates { get; set; }
        public PackageStatus Status { get; set; }
        public PackageStatusMessages Messages { get; set; }
        public PackageLocation Location { get; set; }
        public bool CreatedManually { get; set; } = false;
        public bool IsSoftDeleted { get; set; } = false;
        public bool IsBeingWatched { get; set; } = false;

        private PackageTemporaryStates TemporaryStates { get; set; } = new PackageTemporaryStates();

        public Package()
        {
            Dates = new PackageDates();
            Status = new PackageStatus();
            Location = new PackageLocation();
            Messages = new PackageStatusMessages();
            IsSoftDeleted = false;
            BoundPlatform = AvailablePlatformsToBind.None;
            TemporaryStates = new PackageTemporaryStates();
        }

        public void SetModifiedStateNow()
        {

            if (TemporaryStates.IsDatesModified)
            {
                Dates.SetLastModifiedNow();
            }
        }
    }

    public class PackageTemporaryStates
    {
        public bool IsDatesModified { get; set; } = false;
    }

    public class PackageStatus
    {
        public bool HasBeenDelivered { get; set; } = false;
        public bool HasBeenPosted { get; set; } = false;
        public bool IsAwaitingForPickUp { get; set; } = false;
        public bool IsRejected { get; set; } = false;
        public bool IsBeingTransported { get; set; } = false;
    }

    public class PackageDates
    {
        public DateTime PostedAt { get; set; }
        public DateTime DeliveredAt { get; set; }
        public DateTime LastModifiedAt { get; set; } = DateTime.MinValue;
        public DateTime CreatedAt { get; private set; } = DateTime.MinValue;
        public DateTime LastUpdated { get; set; } = DateTime.MinValue;
        public PackageDates()
        {
            CreatedAt = DateTime.UtcNow;
            PostedAt = DateTime.UtcNow;
            DeliveredAt = DateTime.UtcNow;
            LastModifiedAt = DateTime.UtcNow;
        }
        public void SetLastModifiedNow()
        {
            LastModifiedAt = DateTime.UtcNow;
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

    public class PackageContactInformation
    {
        public string MobilePhoneNumer { get; set; }
    }

    public enum AvailablePlatformsToBind
    {
        MercadoLivre = 0,
        B2W = 1,
        None = 10
    }
}
