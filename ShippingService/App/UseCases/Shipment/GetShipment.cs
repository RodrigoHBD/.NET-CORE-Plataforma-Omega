using ShippingService.App.Boundries;
using ShippingService.App.Entities;
using ShippingService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.UseCases
{
    public class GetShipment
    {
        public async Task<Shipment> ById(string id)
        {
            try
            {
                await ShipmentEntity.ValidateId(id);
                return await ShipmentDAO.Methods.GetBy.Id(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Shipment> ByPackageId(string id)
        {
            return await ShipmentDAO.Methods.GetBy.PackageId(id);
        }
    }
}
