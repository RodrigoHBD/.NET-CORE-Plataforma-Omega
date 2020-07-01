using ShippingService.App.Boundries;
using ShippingService.App.Entities.PackageStatusInterpreter;
using ShippingService.App.Entities.PackageStatusPossibleStates;
using ShippingService.App.Factories;
using ShippingService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Entities
{
    public class PackageStatusEntity
    {
        private static List<IPackageStateMatcher> States { get; } = new List<IPackageStateMatcher>()
        {
            new NotPosted(),
            new Posted(),
            new OnTheMove()
        };

        public static List<PackageActionHandler> FindCurrentStateActionHandlers(PackageStatus status)
        {
            try
            {
                var handlers = new List<PackageActionHandler>();

                States.ForEach(state => 
                {
                    if (state.Match(status))
                    {
                        handlers.Add(state.ActionHandler);
                    }
                });

                return handlers;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static PackageStatusChangesReport CreateChangesReport(PackageStatus current, PackageStatus fetched)
        {
            try
            {
                var report = new PackageStatusChangesReport();

                if (fetched.HasBeenPosted != current.HasBeenPosted)
                {
                    report.PostedMustUpdate = true;
                }

                if (fetched.IsBeingTransported != current.IsBeingTransported)
                {
                    report.IsBeingTransportedMustUpdate = true;
                }

                if(fetched.IsAwaitingForPickUp != current.IsAwaitingForPickUp)
                {
                    report.AwaitingForPickUpMustUpdate = true;
                }

                if(fetched.IsBeingTransported != current.IsBeingTransported)
                {
                    report.IsBeingTransportedMustUpdate = true;
                }

                if(fetched.HasBeenDelivered != current.HasBeenDelivered)
                {
                    report.DeliveredMustUpdate = true;
                }

                if(fetched.IsRejected != current.IsRejected)
                {
                    report.IsRejectedMustUpdate = true;
                }

                return report;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task SetPackageStatusIsBeingTransported(string id, bool toggle)
        {
            try
            {
                var update = PackageFactory.MakePackageIsBeingTransportedUpdate(toggle);
                await PackageDAO.UpdatePackage(id, update);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task SetPackageStatusHasBeenDelivered(string id)
        {
            try
            {
                var update = PackageFactory.MakePackageDeliveredUpdate();
                await PackageDAO.UpdatePackage(id, update);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task SetPackageStatusHasBeenPosted(string id)
        {
            try
            {
                var update = PackageFactory.MakePackagePostedUpdate();
                await PackageDAO.UpdatePackage(id, update);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task SetPackageStatusHasBeenRejected(string id)
        {
            try
            {
                var update = PackageFactory.MakePackageIsRejectedUpdate();
                await PackageDAO.UpdatePackage(id, update);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task SetPackageStatusIsAwaitingForPickUp(string id, bool toggle)
        {
            try
            {
                var update = PackageFactory.MakePackageAwaitingForPickUpUpdate(toggle);
                await PackageDAO.UpdatePackage(id, update);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task SetPackageStatusMessage(string id, string message)
        {
            try
            {
                var update = PackageFactory.MakePackageStatusMessageUpdate(message);
                await PackageDAO.UpdatePackage(id, update);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task SetPackageCurrentLocation(string id, Location location)
        {
            try
            {
                var update = PackageFactory.MakePackageCurrentLocationUpdate(location);
                await PackageDAO.UpdatePackage(id, update);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task SetPackageHeadedToLocation(string id, Location location)
        {
            try
            {
                var update = PackageFactory.MakePackageHeadedToLocationUpdate(location);
                await PackageDAO.UpdatePackage(id, update);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task SetPackageCommingFromLocation(string id, Location location)
        {
            try
            {
                var update = PackageFactory.MakePackageCommingFromLocationUpdate(location);
                await PackageDAO.UpdatePackage(id, update);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}
