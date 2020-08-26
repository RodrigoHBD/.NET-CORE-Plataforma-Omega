using ShippingService.App.Boundries;
using ShippingService.App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.UseCases
{
    public class DeleteShipment
    {
        public async Task Execute(string id)
        {
            try
            {
                await ValdiateId(id);
                var shipmentId = await GetShipmentId(id);
                await DeletePackage.Execute(shipmentId);
                await ShipmentDAO.Methods.Delete.Execute(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task ValdiateId(string id)
        {
            await ShipmentEntity.ValidateId(id);
        }

        private async Task<string> GetShipmentId(string id)
        {
            var shipment = await ShipmentUseCases.Get.ById(id);
            return shipment.PackageId;
        }

    }
}
