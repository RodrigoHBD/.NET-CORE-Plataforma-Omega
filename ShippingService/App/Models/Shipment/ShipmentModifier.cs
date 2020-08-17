using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Models
{
    public class ShipmentModifier
    {
        public static ShipmentModifier Empity
        {
            get
            {
                return new ShipmentModifier()
                {
                    BeignTransportedSetter = ShipmentModifierSetter.Empity,
                    AwaitingForPickUpSetter = ShipmentModifierSetter.Empity,
                    DeliveredSetter = ShipmentModifierSetter.Empity,
                    PostedSetter = ShipmentModifierSetter.Empity,
                    RejectedSetter = ShipmentModifierSetter.Empity,
                };
            }
        }
        public ShipmentModifierSetter BeignTransportedSetter { get; set; } = new ShipmentModifierSetter();
        public ShipmentModifierSetter PostedSetter { get; set; } = new ShipmentModifierSetter();
        public ShipmentModifierSetter DeliveredSetter { get; set; } = new ShipmentModifierSetter();
        public ShipmentModifierSetter RejectedSetter { get; set; } = new ShipmentModifierSetter();
        public ShipmentModifierSetter AwaitingForPickUpSetter { get; set; } = new ShipmentModifierSetter();

        public ShipmentModifier()
        {
        }
    }

    public class ShipmentModifierSetter
    {
        public static ShipmentModifierSetter Empity
        {
            get
            {
                return new ShipmentModifierSetter()
                {
                    ShouldSet = false,
                    Value = false
                };
            }
        }
        public bool ShouldSet { get; set; } = false;
        public bool Value { get; set; }
    }
}
