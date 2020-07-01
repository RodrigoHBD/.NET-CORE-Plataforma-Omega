using ShippingService.App.Boundries;
using ShippingService.App.CustomExceptions;
using ShippingService.App.Factories;
using ShippingService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Entities
{
    public class PackageEntity
    {
        public static async Task ValidateNewPackage(Package package)
        {
            try
            {
                await ValidateDataFields(package);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task ValidatePackageId(string id)
        {
            try
            {
                var idExist = await PackageDAO.CheckIdPackageIdExist(id);

                if(!idExist)
                {
                    throw new ValidationException("Id", "Esse id não existe");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task SetPackageIsBeingTransported(string id, Location location)
        {
            try
            {
                await ValidatePackageId(id);
                var currentPackageLocation = await PackageDAO.GetPackageCurrentLocation(id);

                await PackageStatusEntity.SetPackageStatusIsBeingTransported(id, true);
                await PackageStatusEntity.SetPackageHeadedToLocation(id, location);
                await PackageStatusEntity.SetPackageCurrentLocation(id, LocationEntity.ExportLocationForBeingTransported());
                await PackageStatusEntity.SetPackageCommingFromLocation(id, currentPackageLocation);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task SetPackageHasArrivedAtLocation(string id, Location location)
        {
            try
            {
                await ValidatePackageId(id);
                await PackageStatusEntity.SetPackageStatusIsBeingTransported(id, false);
                await PackageStatusEntity.SetPackageHeadedToLocation(id, LocationEntity.ExportInstanceOfDefaultLocation());
                await PackageStatusEntity.SetPackageCurrentLocation(id, location);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static async Task ValidateDataFields(Package package)
        {
            try
            {

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
