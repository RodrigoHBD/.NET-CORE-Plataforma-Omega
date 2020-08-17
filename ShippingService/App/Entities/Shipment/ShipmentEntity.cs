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

        public static ShipmentModifier GetActiveModifierFrom(Shipment shipment)
        {
            var method = new GetActiveModifier(shipment);
            return method.Execute();
        }

        public static async Task ValidateId(string id)
        {

        }

        public static ShipmentModifier GetEmpityModifier()
        {
            return ShipmentModifier.Empity;
        }
    }
}
