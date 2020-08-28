using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Models.ShipmentEvents
{
    public class AwaitingForPickUpEvent : IShipmentEvent
    {
        public string Title { get; set; } = "";

        public string Description { get; set; } = "";

        public bool IsSet { get; set; } = false;

        public ShipmentEventDates Dates { get; set; } = new ShipmentEventDates();

        public Location Location { get; set; } = new Location();

        public void SetAwaiting(Location location, DateTime time)
        {
            IsSet = true;
            Location = location;
            Dates.OccurredAt = time;
        }

        public void SetNotAwaiting()
        {
            IsSet = false;
            Location = new Location();
            Dates.OccurredAt = new DateTime();
        }

        public ShipmentModifier GetModifiers()
        {
            if (IsSet)
            {
                return new ShipmentModifier()
                {
                    AwaitingForPickUpSetter = new ShipmentModifierSetter()
                    {
                        ShouldSet = true,
                        Value = true
                    }
                };
            }
            else
            {
                return new ShipmentModifier()
                {
                    AwaitingForPickUpSetter = new ShipmentModifierSetter()
                    {
                        ShouldSet = true,
                        Value = false
                    }
                };
            }
        }

        public AwaitingForPickUpEvent()
        {
            Title = "Aguardando carona.";
        }
    }
}
