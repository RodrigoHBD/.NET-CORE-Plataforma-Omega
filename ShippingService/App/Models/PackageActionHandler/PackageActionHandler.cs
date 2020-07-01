using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Models
{
    public class PackageActionHandler
    {
        public string PackageId { get; set; } 
        public PackageActions Actions { get; set; } = new PackageActions();
    }

    public class PackageAction
    {
        private bool _IsExecutable { get; set; } = false;
        public bool IsSet { get; set; } = false;
        public bool IsExecutable { get { return _IsExecutable; } set { _IsExecutable = value; IsSet = true; } }
        public string ReasonMessage { get; set; } = "";
    }

    public class PackageActions
    {
        public PackageAction SetPosted { get; } = new PackageAction();
        public PackageAction SetDelivered { get; } = new PackageAction();
        public PackageAction SetBeingTransported { get; } = new PackageAction();
        public PackageAction SetIsAwaitingForPickUp { get; } = new PackageAction();
        public PackageAction SetIsRejected { get; } = new PackageAction();
        public PackageAction SetCurrentLocation { get; } = new PackageAction();
        public PackageAction SetHeadedToLocation { get; } = new PackageAction();
    }
}
