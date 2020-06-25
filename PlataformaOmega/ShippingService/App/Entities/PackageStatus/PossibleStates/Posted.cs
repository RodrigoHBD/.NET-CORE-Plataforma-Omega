using ShippingService.App.Entities.PackageStatusInterpreter;
using ShippingService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Entities.PackageStatusPossibleStates
{
    public class Posted : IPackageStateMatcher
    {
        public string StateLabel { get; } = "Postado";

        public PackageActionHandler ActionHandler { get; } = new PackageActionHandler();

        public Posted()
        {
            ActionHandler.Actions.SetBeingTransported.IsExecutable = true;
            ActionHandler.Actions.SetDelivered.IsExecutable = true;
            ActionHandler.Actions.SetIsAwaitingForPickUp.IsExecutable = true;
            ActionHandler.Actions.SetIsRejected.IsExecutable = true;
            ActionHandler.Actions.SetPosted.IsExecutable = false;
        }

        public bool Match(PackageStatus status)
        {
            if (status.HasBeenPosted)
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
