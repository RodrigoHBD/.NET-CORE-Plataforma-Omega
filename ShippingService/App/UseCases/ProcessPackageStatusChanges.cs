using ShippingService.App.Boundries;
using ShippingService.App.Entities;
using ShippingService.App.Factories;
using ShippingService.App.Models;
using ShippingService.App.Models.MailerService.PackageData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.UseCases
{
    public class ProcessPackageStatusChanges
    {
        public static async Task Execute(Package package, MailerServicePackageData mailerData, PackageChangesReport report)
        {
            try
            {
                await ProcessStatusChanges(package, mailerData.Status, report.Status);
                await ProcessMessagesChanges(package, mailerData.Messages, report.Messages);
                await ProcessLocationsChanges(package, mailerData.Location, report.Locations);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static async Task ProcessStatusChanges(Package package, PackageStatus mailerData, PackageStatusChangesReport report)
        {
            try
            {
                var id = package.Id.ToString();
                var shipment = await ShipmentUseCases.GetBy.ByPackageId(id);
                var actionHandlers = PackageStatusEntity.FindCurrentStateActionHandlers(package.Status);
                var canPost = actionHandlers.Any(handler => !(handler.Actions.SetPosted.IsSet && !handler.Actions.SetPosted.IsExecutable));
                var canMove = actionHandlers.Any(handler => !(handler.Actions.SetBeingTransported.IsSet && !handler.Actions.SetBeingTransported.IsExecutable));
                var canSetAwaitingForPickUp = actionHandlers.Any(handler => !(handler.Actions.SetIsAwaitingForPickUp.IsSet && !handler.Actions.SetIsAwaitingForPickUp.IsExecutable));
                var canReject = actionHandlers.Any(handler => !(handler.Actions.SetIsRejected.IsSet && !handler.Actions.SetIsRejected.IsExecutable));
                var canDeliver = actionHandlers.Any(handler => !(handler.Actions.SetDelivered.IsSet && !handler.Actions.SetDelivered.IsExecutable));

                if (report.PostedMustUpdate && canPost)
                {
                    // PERIGOSO!!! NAO TIRE DO IF PELO AMOR DE DEUS
                    if (shipment != null)
                    {
                        await ShipmentUseCases.Set.PostedEvent(shipment.Id.ToString(),
                        new Models.ShipmentEvents.PostedEvent() { IsPosted = mailerData.HasBeenPosted });
                    }


                    await PackageStatusEntity.SetPackageStatusHasBeenPosted(id);
                    package = await GetPackage.Execute(id);
                    actionHandlers = PackageStatusEntity.FindCurrentStateActionHandlers(package.Status);
                }
                if (report.IsBeingTransportedMustUpdate && canMove)
                {
                    var toggler = mailerData.IsBeingTransported;
                    await PackageStatusEntity.SetPackageStatusIsBeingTransported(id, toggler);

                    if (shipment != null)
                    {
                        
                    }

                    if (toggler == true)
                    {
                        await PackageStatusEntity.SetPackageCurrentLocation(id, LocationEntity.ExportLocationForBeingTransported());
                    }
                }
                if (report.DeliveredMustUpdate && canDeliver)
                {
                    await PackageStatusEntity.SetPackageStatusHasBeenDelivered(id);
                }
                if (report.AwaitingForPickUpMustUpdate && canSetAwaitingForPickUp)
                {
                    await PackageStatusEntity.SetPackageStatusIsAwaitingForPickUp(id, mailerData.IsAwaitingForPickUp);
                }
                if (report.IsRejectedMustUpdate && canReject)
                {
                    await PackageStatusEntity.SetPackageStatusHasBeenRejected(id);
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static async Task ProcessMessagesChanges(Package package, PackageStatusMessages mailerData, PackageMessagesChangesReport report)
        {
            try
            {
                var id = package.Id.ToString();

                if (report.StatusDescriptionMustUpdate)
                {
                    await PackageStatusEntity.SetPackageStatusMessage(id, mailerData.StatusDescription);
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static async Task ProcessLocationsChanges(Package package, PackageLocation mailerData, PackageLocationChangesReport report)
        {
            try
            {
                var id = package.Id.ToString();
                var actionHandlers = PackageStatusEntity.FindCurrentStateActionHandlers(package.Status);
                var canSetCurrentLocation = actionHandlers.Any(handler => !(handler.Actions.SetCurrentLocation.IsSet && !handler.Actions.SetCurrentLocation.IsExecutable));
                var canSetHeadedToLocation = actionHandlers.Any(handler => !(handler.Actions.SetHeadedToLocation.IsSet && !handler.Actions.SetHeadedToLocation.IsExecutable));

                if (report.CurrentLocationMustUpdate && canSetCurrentLocation)
                {
                    await PackageStatusEntity.SetPackageCurrentLocation(id, mailerData.CurrentLocation);
                }
                if (report.HeadedToLocationMustUpdate && canSetHeadedToLocation)
                {
                    await PackageStatusEntity.SetPackageHeadedToLocation(id, mailerData.HeadedTo);
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
