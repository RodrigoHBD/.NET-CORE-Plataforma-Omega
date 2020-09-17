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

        public bool IsUserNotified { get; set; } = false;

        public ShipmentEventDates Dates { get; private set; }

        public void SetOccuredAtToNow()
        {
            var timezone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            Dates.OccurredAt = TimeZoneInfo.ConvertTime(DateTime.Now, timezone);
        }

        public ShipmentModifier GetModifiers()
        {
            throw new NotImplementedException();
        }

    }
}
