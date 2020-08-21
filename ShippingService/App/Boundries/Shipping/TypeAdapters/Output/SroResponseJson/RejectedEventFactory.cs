using ShippingService.App.Models.ShipmentEvents;
using ShippingService.Correios.Models.Sro;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Boundries.MailerTypeAdapters.Output
{
    public class RejectedEventFactory
    {
        public RejectedEvent GetEvent()
        {
            return new RejectedEvent()
            {
                IsRejected = GetIsRejected(),
                Dates = new Models.ShipmentEventDates()
                {
                    OccuredAt = GetDateTime()
                }
            };
        }

        public RejectedEventFactory(SroJsonResponse json)
        {
            Json = json;
        }

        private SroJsonResponse Json { get; }

        private bool GetIsRejected()
        {
            var isRejected = false;

            Json.evento.ForEach(evento =>
            {
                var rejectedBDE = evento.tipo[0] == "BDE" && (evento.status[0] == "04" || evento.status[0] == "05"
                || evento.status[0] == "06" || evento.status[0] == "07" || evento.status[0] == "08" || evento.status[0] == "10"
                || evento.status[0] == "21" || evento.status[0] == "26" || evento.status[0] == "36" || evento.status[0] == "48"
                || evento.status[0] == "49" || evento.status[0] == "89");

                var rejectedBDI = evento.tipo[0] == "BDI" && (evento.status[0] == "04" || evento.status[0] == "05"
                || evento.status[0] == "06" || evento.status[0] == "07" || evento.status[0] == "08" || evento.status[0] == "10"
                || evento.status[0] == "21" || evento.status[0] == "26" || evento.status[0] == "36" || evento.status[0] == "48"
                || evento.status[0] == "49" || evento.status[0] == "89");

                var rejectedBDR = evento.tipo[0] == "BDR" && (evento.status[0] == "04" || evento.status[0] == "05"
                || evento.status[0] == "06" || evento.status[0] == "07" || evento.status[0] == "08" || evento.status[0] == "10"
                || evento.status[0] == "21" || evento.status[0] == "26" || evento.status[0] == "36" || evento.status[0] == "48"
                || evento.status[0] == "49" || evento.status[0] == "64");

                var rejectedFC = evento.tipo[0] == "FC" && (evento.status[0] == "01");

                if (rejectedBDE || rejectedBDI || rejectedBDR || rejectedFC)
                {
                    isRejected = true;
                }
            });
            return isRejected;
        }

        private SroEvent GetRejectionEvent()
        {
            var @event = new SroEvent();

            Json.evento.ForEach(evento =>
            {
                var rejectedBDE = evento.tipo[0] == "BDE" && (evento.status[0] == "04" || evento.status[0] == "05"
                 || evento.status[0] == "06" || evento.status[0] == "07" || evento.status[0] == "08" || evento.status[0] == "10"
                 || evento.status[0] == "21" || evento.status[0] == "26" || evento.status[0] == "36" || evento.status[0] == "48"
                 || evento.status[0] == "49" || evento.status[0] == "89");

                var rejectedBDI = evento.tipo[0] == "BDI" && (evento.status[0] == "04" || evento.status[0] == "05"
                || evento.status[0] == "06" || evento.status[0] == "07" || evento.status[0] == "08" || evento.status[0] == "10"
                || evento.status[0] == "21" || evento.status[0] == "26" || evento.status[0] == "36" || evento.status[0] == "48"
                || evento.status[0] == "49" || evento.status[0] == "89");

                var rejectedBDR = evento.tipo[0] == "BDR" && (evento.status[0] == "04" || evento.status[0] == "05"
                || evento.status[0] == "06" || evento.status[0] == "07" || evento.status[0] == "08" || evento.status[0] == "10"
                || evento.status[0] == "21" || evento.status[0] == "26" || evento.status[0] == "36" || evento.status[0] == "48"
                || evento.status[0] == "49" || evento.status[0] == "64");

                var rejectedFC = evento.tipo[0] == "FC" && (evento.status[0] == "01");

                if (rejectedBDE || rejectedBDI || rejectedBDR || rejectedFC)
                {
                    @event = evento;
                }
            });

            return @event;
        }

        private DateTime GetDateTime()
        {
            var isRejected = GetIsRejected();

            if (isRejected)
            {
                var @event = GetRejectionEvent();
                var hours = @event.hora[0];
                var date = @event.data[0];
                return DateTime.Parse($"{date} {hours}", new CultureInfo("pt-BR"));
            }

            return DateTime.MaxValue;
        }

    }
}
