using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Models.ShipmentEvents
{
    public class RejectedEvent : IShipmentEvent
    {
        public string Title { get; private set; }

        public string Description
        {
            get
            {
                if (IsRejected)
                {
                    return "O pacote foi rejeitado";
                }
                return "O pacote nao foi rejeitado";
            }
        }

        public ShipmentEventDates Dates { get; set; } = new ShipmentEventDates();

        public bool IsRejected { get; set; } = false;

        public bool IsUserNotified { get; set; } = false;

        public ShipmentModifier GetModifiers()
        {
            if (IsRejected)
            {
                return new ShipmentModifier()
                {
                    RejectedSetter = new ShipmentModifierSetter()
                    {
                        ShouldSet = true,
                        Value = true
                    }
                };
            }
            else
            {
                return ShipmentModifier.Empity;
            }
        }

        public RejectedEvent()
        {
            Title = "Rejeicao";
        }
    }
}
