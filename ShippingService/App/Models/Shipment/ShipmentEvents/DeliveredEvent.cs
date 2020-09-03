using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Models.ShipmentEvents
{
    public class DeliveredEvent : IShipmentEvent
    {
        public string Title { get; private set; } = "";

        public string Description
        {
            get
            {
                if (IsDelivered)
                {
                    if (IsDeliveredToDestination)
                    {
                        return $"O pacote foi entregue destinatario";
                    }
                    return "O pacote voltou para o remetente";
                }
                return "";
            }
        }

        public bool IsDelivered { get; set; } = false;

        public bool IsDeliveredToDestination { get; set; } = false;

        public bool IsDeliveryConfirmed { get; set; } = false;

        public ShipmentEventDates Dates { get; set; }

        public ShipmentModifier GetModifiers()
        {
            if (IsDelivered)
            {
                return GetDeliveredModifiers();
            }
            else
            {
                return GetNotDeliveredModifiers();
            }
        }

        private ShipmentModifier GetDeliveredModifiers()
        {
            return new ShipmentModifier()
            {
                DeliveredSetter = new ShipmentModifierSetter()
                {
                    ShouldSet = true,
                    Value = true
                }
            };
        }

        private ShipmentModifier GetNotDeliveredModifiers()
        {
            return ShipmentModifier.Empity;
        }
    }
}
