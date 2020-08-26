using ShippingService.App.Entities;
using ShippingService.App.Models;
using ShippingService.App.Models.ShipmentEvents;
using ShippingService.Correios.Models.Sro;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Boundries.MailerTypeAdapters.Output
{
    public class AwaitingForPickUpEventFactory
    {
        public AwaitingForPickUpEvent GetEvent()
        {
            return new AwaitingForPickUpEvent()
            {
                IsSet = GetIsSet(),
                Location = GetLocation(),
                Dates = new Models.ShipmentEventDates()
                {
                    OccuredAt = GetDateTime()
                }
            };
        }

        public AwaitingForPickUpEventFactory(SroJsonResponse json)
        {
            Json = json;
        }

        private SroJsonResponse Json { get; }

        private bool GetIsSet()
        {
            var isAwaitingForPickUp = false;
            var hasOneEvent = Json.evento.Count > 0;

            if (hasOneEvent)
            {
                var evento = Json.evento[0];
                var awaitingBDE = evento.tipo[0] == "BDE" && (evento.status[0] == "24");
                var awaitingBDI = evento.tipo[0] == "BDI" && (evento.status[0] == "24");
                var awaitingBDR = evento.tipo[0] == "BDR" && (evento.status[0] == "24");
                var awaitingLDI = evento.tipo[0] == "LDI" && (evento.status[0] == "01" || evento.status[0] == "02"
                    || evento.status[0] == "03" || evento.status[0] == "04" || evento.status[0] == "11" || evento.status[0] == "13");

                if (awaitingBDE || awaitingBDI || awaitingBDR || awaitingLDI)
                {
                    isAwaitingForPickUp = true;
                }
            }

            return isAwaitingForPickUp;
        }

        private SroEvent GetAwaitingForPickUpEvent()
        {
            var @event = new SroEvent();

            Json.evento.ForEach(evento =>
            {
                var awaitingBDE = evento.tipo[0] == "BDE" && (evento.status[0] == "24");
                var awaitingBDI = evento.tipo[0] == "BDI" && (evento.status[0] == "24");
                var awaitingBDR = evento.tipo[0] == "BDR" && (evento.status[0] == "24");
                var awaitingLDI = evento.tipo[0] == "LDI" && (evento.status[0] == "01" || evento.status[0] == "02"
                    || evento.status[0] == "03" || evento.status[0] == "04" || evento.status[0] == "11" || evento.status[0] == "13");

                if (awaitingBDE || awaitingBDI || awaitingBDR || awaitingLDI)
                {
                    @event = evento;
                }
            });

            return @event;
        }

        private DateTime GetDateTime()
        {
            var isSet = GetIsSet();

            if (isSet)
            {
                var @event = GetAwaitingForPickUpEvent();
                var hours = @event.hora[0];
                var date = @event.data[0];
                return DateTime.Parse($"{date} {hours}", new CultureInfo("pt-BR"));
            }

            return DateTime.MaxValue;
        }

        private Location GetLocation()
        {
            var isSet = GetIsSet();

            if (isSet)
            {
                var @event = GetAwaitingForPickUpEvent();
                return new Location()
                {
                    Cep = @event.codigo[0],
                    City = @event.cidade[0],
                    State = @event.uf[0],
                    StreetName = @event.local[0]
                };
            }

            return new Location();
        }
    }
}
