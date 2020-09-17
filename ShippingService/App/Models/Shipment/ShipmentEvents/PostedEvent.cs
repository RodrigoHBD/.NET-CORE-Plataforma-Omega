using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Models.ShipmentEvents
{
    public class PostedEvent : IShipmentEvent
    {
        public string Title { get; set; } = "Postagem";

        public string Description
        {
            get
            {
                if (IsPosted)
                {
                    return "O pacote foi postado.";
                }
                return "O pacote ainda nao foi postado.";
            }
        }

        public bool IsPosted { get; set; } = false;

        public bool IsUserNotified { get; set; } = false;

        public ShipmentEventDates Dates { get; set; } = new ShipmentEventDates();

        public ShipmentModifier GetModifiers()
        {
            if (IsPosted)
            {
                return GetPostedModifier();
            }
            else
            {
                return GetNotPostedModifier();
            }
        }

        private ShipmentModifier GetPostedModifier()
        {
            return new ShipmentModifier()
            {
                PostedSetter = new ShipmentModifierSetter()
                {
                    ShouldSet = true,
                    Value = true
                }
            };
        }

        private ShipmentModifier GetNotPostedModifier()
        {
            return ShipmentModifier.Empity;
        }
    }
}
