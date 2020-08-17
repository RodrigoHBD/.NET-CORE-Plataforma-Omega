using ShippingService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace ShippingService.App.Entities.ShipmentMethods
{
    public class GetActiveModifier
    {
        //public props

        //public methods
        public ShipmentModifier Execute()
        {
            return GetModifier();
        }
    
        public GetActiveModifier(Shipment shipment)
        {
            Shipment = shipment;
        }

        // private props
        private Shipment Shipment { get; set; }

        // private methods
        private ShipmentModifier GetModifier()
        {
            return new ShipmentModifier()
            {
                PostedSetter = GetPostedSetter(),
                BeignTransportedSetter = GetBeingTransportedSetter(),
                AwaitingForPickUpSetter = GetAwaitingForPickUpSetter()
            };
        }

        private ShipmentModifierSetter GetBeingTransportedSetter()
        {
            var hasAtLeastOneEvent = Shipment.ForwardingEvents.Count > 0;

            if (hasAtLeastOneEvent)
            {
                var length = Shipment.ForwardingEvents.Count;
                return Shipment.ForwardingEvents[length].GetModifiers().BeignTransportedSetter;
            }
            else
            {
                return ShipmentEntity.GetEmpityModifier().BeignTransportedSetter;
            }
        }

        private ShipmentModifierSetter GetPostedSetter()
        {
            return Shipment.PostedEvent.GetModifiers().PostedSetter;
        }

        private ShipmentModifierSetter GetAwaitingForPickUpSetter()
        {
            return Shipment.AwaitingForPickUpEvent.GetModifiers().AwaitingForPickUpSetter;
        }
    }
}
