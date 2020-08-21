using ShippingService.App.Boundries;
using ShippingService.App.Models;
using System;
using System.Threading.Tasks;

namespace ShippingService.App.UseCases
{
    public class RegisterShipment
    {
        public async Task<string> Execute(Shipment shipment)
        {
            try
            {
                await ShipmentDAO.Methods.Register.Execute(shipment);
                return shipment.Id.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
