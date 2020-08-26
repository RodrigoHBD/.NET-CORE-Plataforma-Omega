using ShippingService.App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.UseCases
{
    public class ShipmentUseCaseController
    {
        public static async Task RunAutoUpdateById(string id)
        {
            try
            {
                await ShipmentEntity.ValidateId(id);
                var shipment = await ShipmentUseCases.Get.ById(id);
                await ShipmentUseCases.UpdateShipmentWithBoundry(shipment);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
