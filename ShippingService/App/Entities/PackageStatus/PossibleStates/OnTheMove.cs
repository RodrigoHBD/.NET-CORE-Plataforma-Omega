using ShippingService.App.Entities.PackageStatusInterpreter;
using ShippingService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Entities.PackageStatusPossibleStates
{
    public class OnTheMove : IPackageStateMatcher
    {
        public string StateLabel { get; } = "Em Trânsito";

        public PackageActionHandler ActionHandler { get; } = new PackageActionHandler();

        public OnTheMove()
        {
            ActionHandler.Actions.SetBeingTransported.IsExecutable = false;
            ActionHandler.Actions.SetDelivered.IsExecutable = true;
            ActionHandler.Actions.SetIsAwaitingForPickUp.IsExecutable = false;
            ActionHandler.Actions.SetIsRejected.IsExecutable = true;
            ActionHandler.Actions.SetPosted.IsExecutable = false;
            ActionHandler.Actions.SetCurrentLocation.IsExecutable = false;
        }

        public bool Match(PackageStatus status)
        {
            if (status.IsBeingTransported)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
