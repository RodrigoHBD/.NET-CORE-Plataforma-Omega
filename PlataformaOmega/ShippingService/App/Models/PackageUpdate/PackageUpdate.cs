using ShippingService.App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Models
{
    public class PackageUpdate
    {
        public bool SetPosted { get; set; } = false;
        public bool SetDelivered { get; set; } = false;
        public bool SetAwaitingForPickUp { get; set; } = false;
        public bool SetIsRejected { get; set; } = false;
        public bool SetIsBeingTransported { get; set; } = false;
        public string StatusMessage { get; set; } = "";
        public DateTime UpdateTime { get; set; }
        public PackageLocationUpdate CommingFrom { get; set; }
        public PackageLocationUpdate HeadedTo { get; set; }
        public PackageLocationUpdate CurrentLocation { get; set; }
        public PackageUpdate()
        {
            UpdateTime = DateTime.Now;
            CommingFrom = new PackageLocationUpdate();
            HeadedTo = new PackageLocationUpdate();
            CurrentLocation = new PackageLocationUpdate();
        }
    }

    public class PackageLocationUpdate
    {
        public bool MustUpdate { get; set; } = false;
        public Location Location { get; set; } = LocationEntity.ExportInstanceOfDefaultLocation();
    }
}
