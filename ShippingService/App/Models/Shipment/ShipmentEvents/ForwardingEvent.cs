using ShippingService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Models.ShipmentEvents
{
    public class ForwardingEvent : IShipmentEvent
    {
        // public props
        public string Title { get; set; } 

        public string Description { get; set; }

        public string BoundryMessage { get; set; }

        public bool PackageHasArrived { get; set; }

        public bool IsUserNotified { get; set; } = false;

        public ForwardedToLocations Locations { get; set; } = new ForwardedToLocations();

        public ShipmentEventDates Dates { get; set; } = new ShipmentEventDates();

        public DateTime ArrivedAt { get; set; }

        //public methods
        public ShipmentModifier GetModifiers()
        {
            if (PackageHasArrived)
            {
                return GetArrivedModifiers();
            }
            else
            {
                return GetNotArrivedModifiers();
            }
        }

        public void SetForwardedToLocation(Location location)
        {
            Locations.ForwardedTo = location;
        }

        public void SetArrived(DateTime time)
        {
            PackageHasArrived = true;
            ArrivedAt = time;
        }

        public ForwardingEvent()
        {
            Title = "Enviado";
            Description = "O pacote de entrega foi enviado para uma localizacao";
            PackageHasArrived = false;
        }

        // private props

        private ShipmentModifier GetArrivedModifiers()
        {
            return new ShipmentModifier()
            {
                BeignTransportedSetter = new ShipmentModifierSetter()
                {
                    ShouldSet = true,
                    Value = false
                }
            };
        }

        private ShipmentModifier GetNotArrivedModifiers()
        {
            return new ShipmentModifier()
            {
                BeignTransportedSetter = new ShipmentModifierSetter()
                {
                    ShouldSet = true,
                    Value = true
                }
            };
        }
    }

    public class ForwardedToLocations
    {
        public Location ForwardedFrom { get; set; }
        public Location ForwardedTo { get; set; }
    }

}
