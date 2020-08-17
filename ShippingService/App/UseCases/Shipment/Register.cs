using ShippingService.App.Boundries;
using ShippingService.App.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.UseCases
{
    public class RegisterShipment
    {
        public async Task<string> Execute(string packageId)
        {
            var shipment = ShipmentFactory.CreateShipment(packageId);
            await ShipmentDAO.Methods.Register.Execute(shipment);
            return shipment.Id.ToString();
        }
    }
}
