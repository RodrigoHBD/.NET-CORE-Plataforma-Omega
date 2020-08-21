using ShippingService.App.Boundries;
using ShippingService.App.Entities.ShipmentDataField;
using ShippingService.App.Entities.ShipmentMethods;
using ShippingService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Entities
{
    public class ShipmentEntity
    {
        public static ShipmentDataFields DataFields { get; private set; } = new ShipmentDataFields();

        public static async Task ValidateNew(Shipment shipment)
        {
            try
            {
                var method = new ValidateNewShipment(shipment);
                await method.Execute();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static ShipmentModifier GetActiveModifierFrom(Shipment shipment)
        {
            try
            {
                var method = new GetActiveModifier(shipment);
                return method.Execute();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task ValidateId(string id)
        {
            try
            {
                var exists = await ShipmentDAO.Methods.GetBy.IdBool(id);

                if (!exists)
                {
                    throw new Exception("Esse envio nao existe");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static ShipmentModifier GetEmpityModifier()
        {
            return ShipmentModifier.Empity;
        }
    }
}
