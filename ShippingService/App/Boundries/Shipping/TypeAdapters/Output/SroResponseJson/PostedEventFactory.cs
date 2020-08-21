using ShippingService.App.Models.ShipmentEvents;
using ShippingService.Correios.Models.Sro;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Boundries.MailerTypeAdapters.Output
{
    public class PostedEventFactory
    {
        public PostedEvent GetPostedEvent()
        {
            return new PostedEvent()
            {
                IsPosted = GetIsPosted(),
                Dates = new Models.ShipmentEventDates() 
                { 
                    OccuredAt = GetPostingDateTime()
                }
            };
        }

        public PostedEventFactory(SroJsonResponse json)
        {
            Json = json;
        }

        private SroJsonResponse Json { get; }

        private bool GetIsPosted()
        {
            var isPosted = false;
            Json.evento.ForEach(evento =>
            {
                isPosted = evento.tipo[0] == "PO" && (evento.status[0] == "09" || evento.status[0] == "01");
            });
            return isPosted;
        }

        private SroEvent GetPostingEvent()
        {
            var @event = new SroEvent();

            Json.evento.ForEach(evento =>
            {
                var tiposList = new List<string>() { "PO" };
                var statusList = new List<string>() { "01", "09" };
                var tipoOk = tiposList.Contains(evento.tipo[0]);
                var StatusOk = statusList.Contains(evento.status[0]);

                if (tipoOk && StatusOk)
                {
                    @event = evento;
                }
            });

            return @event;
        }

        private DateTime GetPostingDateTime()
        {
            var isPosted = GetIsPosted();

            if (isPosted)
            {
                var @event = GetPostingEvent();
                var hours = @event.hora[0];
                var date = @event.data[0];
                return DateTime.Parse($"{date} {hours}", new CultureInfo("pt-BR"));
            }

            return new DateTime();
        }

    }
}
