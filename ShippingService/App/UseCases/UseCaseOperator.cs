using ShippingService.App.Entities;
using ShippingService.App.Entities.PackageSearch;
using ShippingService.App.Factories;
using ShippingService.App.Models;
using ShippingService.App.Models.Input;
using ShippingService.App.Models.Output;
using System;
using System.Threading.Tasks;

namespace ShippingService.App.UseCases
{
    public class UseCaseOperator
    {
        public static async Task CreateNewShipment(NewShipmentRequest request)
        {
            try
            {
                var package = PackageFactory.CreatePackage(request.PackageData);
                await PackageEntity.ValidateNew(package);
                
                var shipment = ShipmentFactory.CreateShipment(request);
                await ShipmentEntity.ValidateNew(shipment);

                await PackageUseCases.RegisterPackage.Execute(package);
                await ShipmentUseCases.RegisterShipment.Execute(shipment);
                await ShipmentUseCases.Set.PackageId(shipment.Id.ToString(), package.Id.ToString());
                await ShipmentUseCases.UpdateShipmentWithBoundry(shipment);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static async Task<Package> GetPackageData(string id)
        {
            try
            {
                await PackageEntity.ValidatePackageId(id);
                return await GetPackage.Execute(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task WatchPackage(string id)
        {
            try
            {
                
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task StopWatchingPackage(string id)
        {
            try
            {
             
               
               
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task<PackageList> SearchPackagesAsync(SearchPackageRequest request)
        {
            try
            {
                //PackageSearchEntity.ValidateRequest(request);
                //return await SearchPackages.Execute(request);
                return new PackageList();
            }
            catch (Exception e)
            {
                throw;
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

        public static async Task RunWatcherRoutine(string packageId)
        {
            try
            {
                var shipment = await ShipmentUseCases.Get.ByPackageId(packageId);
                await ShipmentUseCases.UpdateShipmentWithBoundry(shipment);
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
