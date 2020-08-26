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

        public static async Task RunShipmentAutoUpdate()
        {
            try
            {
                await ShipmentUseCases.RunAutoUpdate.Execute();
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
