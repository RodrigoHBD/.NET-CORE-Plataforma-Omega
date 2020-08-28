using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShippingService.App.Models;

namespace ShippingService.App.Models.ShipmentEvents
{
    public class CreatedEvent : IShipmentEvent
    {
        public CreatedEvent()
        {
            Title = "Criado";
            Description = "Evento de criacao do envio";
            Dates = new ShipmentEventDates();
            SetOccuredAtToNow();
        }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public ShipmentEventDates Dates { get; private set; }

        public void SetOccuredAtToNow()
        {
            Dates.OccurredAt = DateTime.UtcNow;
        }

        public ShipmentModifier GetModifiers()
        {
            throw new NotImplementedException();
        }

    }
}
