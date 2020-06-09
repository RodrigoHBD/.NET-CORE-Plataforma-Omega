using ShippingService.App.Boundries;
using ShippingService.App.Entities;
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
        public static async Task Execute(Package package, PackageChangesReport report, MailerServicePackageData packageData)
        {
            try
            {
                await ProcessReports(package.Id.ToString(), report, packageData);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static async Task ProcessReports(string id, PackageChangesReport report, MailerServicePackageData packageData)
        {
            try
            {
                var currentPackageStatus = await PackageDAO.GetPackageStatus(id);
                var somethingChangedAndPackageIsNotDelivered = report.Status.AnythingChanged && !currentPackageStatus.HasBeenDelivered;
                var somthingChangedAndPackageIsDelivered = currentPackageStatus.HasBeenDelivered && report.Status.AnythingChanged;
                var packageBeingTransported = (currentPackageStatus.IsBeingTransported && !report.Status.IsBeingTransportedMustUpdate) || (!currentPackageStatus.IsBeingTransported && report.Status.IsBeingTransportedMustUpdate);

                if (somethingChangedAndPackageIsNotDelivered)
                {
                    if (report.Status.PostedMustUpdate)
                    {
                        await UseCaseOperator.SetPackagePosted(id);
                    }
                    if (report.Status.IsBeingTransportedMustUpdate)
                    {
                        await PackageStatusEntity.SetPackageStatusIsBeingTransported(id, packageData.Status.IsBeingTransported);
                    }
                    if (report.Status.AwaitingForPickUpMustUpdate)
                    {
                        await PackageStatusEntity.SetPackageStatusIsAwaitingForPickUp(id, packageData.Status.IsAwaitingForPickUp);
                    }
                    if (report.Status.IsRejectedMustUpdate)
                    {
                        await PackageStatusEntity.SetPackageStatusHasBeenRejected(id);
                    }
                    if (report.Status.MessageMustUpdate)
                    {
                        await PackageStatusEntity.SetPackageStatusMessage(id, packageData.Status.Message);
                    }
                    if (report.Status.DeliveredMustUpdate)
                    {
                        await PackageStatusEntity.SetPackageStatusHasBeenDelivered(id);
                    }


                    if (packageBeingTransported)
                    {
                        if (report.Locations.CommingFromLocationMustUpdate)
                        {
                            await PackageStatusEntity.SetPackageCommingFromLocation(id, packageData.Location.CommingFrom);
                        }
                        if (report.Locations.HeadedToLocationMustUpdate)
                        {
                            await PackageStatusEntity.SetPackageHeadedToLocation(id, packageData.Location.HeadedTo);
                        }
                    }
                    else
                    {
                        if (report.Locations.CurrentLocationMustUpdate)
                        {
                            await PackageStatusEntity.SetPackageCurrentLocation(id, packageData.Location.CurrentLocation);
                        }
                    }
                    
                }


                if (somthingChangedAndPackageIsDelivered)
                {
                    throw new Exception("Não pode modificar status de um pacote já entregue");
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
