using ShippingService.App.Entities.PackageStatusInterpreter;
using ShippingService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Entities.PackageStatusPossibleStates
{
    public class NotPosted : IPackageStateMatcher
    {
        public string StateLabel { get; } = "Não Postado";
        public PackageActionHandler ActionHandler { get; } = new PackageActionHandler();

        public NotPosted()
        {
            ActionHandler.Actions.SetBeingTransported.IsExecutable = false;
            ActionHandler.Actions.SetDelivered.IsExecutable = false;
            ActionHandler.Actions.SetIsAwaitingForPickUp.IsExecutable = false;
            ActionHandler.Actions.SetIsRejected.IsExecutable = false;
            ActionHandler.Actions.SetPosted.IsExecutable = true;
        }

        public bool Match(PackageStatus status)
        {
            if (!status.HasBeenPosted)
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
