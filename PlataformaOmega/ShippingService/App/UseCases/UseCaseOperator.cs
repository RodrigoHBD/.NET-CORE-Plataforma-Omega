using ShippingService.App.Entities;
using ShippingService.App.Entities.NewPackageRequest;
using ShippingService.App.Models;
using ShippingService.App.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ShippingService.App.UseCases
{
    public class UseCaseOperator
    {
        public static async Task ShipNewPackage(IShipPackageRequest request)
        {
            try
            {
                await ShipPackageRequestEntity.Valdiate(request);
                var package = CreateNewPackage.Execute(request);
                await PackageEntity.ValidateNewPackage(package);
                await RegisterPackage.Execute(package);
                return;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task<Package> GetPackageData(string id)
        {
            try
            {
                await PackageEntity.ValidatePackageId(id);
                await PackageEntity.ValidatePackageId(id);
                return await GetPackage.Execute(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task SetPackagePosted(string id)
        {
            try
            {
                await PackageEntity.ValidatePackageId(id);
                var update = CreatePostedPackageUpdate.Execute();
                await UpdatePackage.Execute(id, update);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task SetPackageDelivered(string id)
        {
            try
            {
                await PackageEntity.ValidatePackageId(id);
                var update = CreateDeliveredPackageUpdate.Execute();
                await UpdatePackage.Execute(id, update);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task HardDeletePackage(string id)
        {
            try
            {
                await PackageEntity.ValidatePackageId(id);
                await DeletePackage.Execute(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //TODO
        public static async Task SoftDeletePackage(string id)
        {
            try
            {
                await PackageEntity.ValidatePackageId(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
