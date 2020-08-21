using ShippingService.App.Models.ShipmentEvents;
using ShippingService.Correios.Models.Sro;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Boundries.MailerTypeAdapters.Output
{
    public class DeliveredEventFactory
    {
        public DeliveredEvent GetDeliveredEvent()
        {
            return new DeliveredEvent()
            {
                IsDelivered = GetIsDelivered(),
                IsDeliveredToDestination = GetIsDeliveredToDestination(),
                Dates = new Models.ShipmentEventDates()
                {
                    OccuredAt = GetDeliveredDate()
                }
            };
        }

        public DeliveredEventFactory(SroJsonResponse json)
        {
            Json = json;
        }

        private SroJsonResponse Json { get; }

        private bool GetIsDelivered()
        {
            var isDelivered = false;

            Json.evento.ForEach(evento =>
            {
                var deliveredBDE = evento.tipo[0] == "BDE" && (evento.status[0] == "01" || evento.status[0] == "23"
                || evento.status[0] == "67" || evento.status[0] == "70");

                var deliveredBDI = evento.tipo[0] == "BDI" && (evento.status[0] == "01" || evento.status[0] == "23"
                || evento.status[0] == "67" || evento.status[0] == "70");

                var deliveredBDR = evento.tipo[0] == "BDR" && (evento.status[0] == "01" || evento.status[0] == "23"
                || evento.status[0] == "67" || evento.status[0] == "70");

                if (deliveredBDE || deliveredBDI || deliveredBDR)
                {
                    isDelivered = true;
                }
            });

            return isDelivered;
        }

        private bool GetIsDeliveredToDestination()
        {
            var isDeliveredToDestination = true;

            Json.evento.ForEach(evento =>
            {
                var deliveredBDE = evento.tipo[0] == "BDE" && (evento.status[0] == "23");

                var deliveredBDI = evento.tipo[0] == "BDI" && (evento.status[0] == "23");

                var deliveredBDR = evento.tipo[0] == "BDR" && (evento.status[0] == "23");

                if (deliveredBDE || deliveredBDI || deliveredBDR)
                {
                    isDeliveredToDestination = false;
                }
            });

            return isDeliveredToDestination;
        }

        private SroEvent GetDeliveryEvent()
        {
            var @event = new SroEvent();

            Json.evento.ForEach(evento =>
            {
                var tiposList = new List<string>() { "BDE", "BDI", "BDR" };
                var statusList = new List<string>() { "01", "23", "67", "70" };
                var tipoOk = tiposList.Contains(evento.tipo[0]);
                var StatusOk = statusList.Contains(evento.status[0]);

                if (tipoOk && StatusOk)
                {
                    @event = evento;
                }
            });

            return @event;
        }

        private DateTime GetDeliveredDate()
        {
            var isDelivered = GetIsDelivered();

            if (isDelivered)
            {
                var @event = GetDeliveryEvent();
                var hours = @event.hora[0];
                var date = @event.data[0];
                return DateTime.Parse($"{date} {hours}", new CultureInfo("pt-BR"));
            }

            return DateTime.MaxValue;
        }

    }
}
