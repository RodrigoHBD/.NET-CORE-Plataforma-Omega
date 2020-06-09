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
        public BoolToggler AwaitingForPickUp { get; set; } = new BoolToggler();
        public bool SetIsRejected { get; set; } = false;
        public BoolToggler IsBeingTransported { get; set; } = new BoolToggler();
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

    public class BoolToggler
    {
        public bool IsActive { get; set; } = false;
        public bool Toggler { get; set; } = false;
    }
}
