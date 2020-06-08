using ShippingService.App.Boundries;
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
