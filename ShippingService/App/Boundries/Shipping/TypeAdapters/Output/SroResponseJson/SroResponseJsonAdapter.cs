using ShippingService.App.Boundries.Shipping;
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
    public class SroResponseJsonAdapter
    {
        public static PostedEvent GetPostedEventFrom(SroJsonResponse json)
        {
            var factory = new PostedEventFactory(json);
            return factory.GetPostedEvent();
        }

        public static DeliveredEvent GetDeliveredEventFrom(SroJsonResponse json)
        {
            var factory = new DeliveredEventFactory(json);
            return factory.GetDeliveredEvent();
        }

        public static AwaitingForPickUpEvent GetAwaitingForPickUpEventFrom(SroJsonResponse json)
        {
            var factory = new AwaitingForPickUpEventFactory(json);
            return factory.GetEvent();
        }

        public static RejectedEvent GetRejectedEventFrom(SroJsonResponse json)
        {
            var factory = new RejectedEventFactory(json);
            return factory.GetEvent();
        }

        public static List<ForwardingEvent> GetForwardingEventListFrom(SroJsonResponse json)
        {
            var factory = new ForwardingEventFactory(json);
            return factory.GetEventList();
        }

        public static string GetLastMessageFrom(SroJsonResponse json)
        {
            var factory = new BoundryMessageFactory(json);
            return factory.GetMessage();
        }

        public static DateTime GetDateTimeFrom(SroEvent @event)
        {
            var hours = @event.hora[0];
            var date = @event.data[0];
            return DateTime.Parse($"{date} {hours}", new CultureInfo("pt-BR"));
        }

        public static Location GetForwarededToLocationFrom(SroEvent @event)
        {
            var destination = @event.destino[0];

            return new Location()
            {
                Cep = destination.codigo[0],
                City = destination.cidade[0],
                State = destination.uf[0],
                StreetName = destination.local[0]
            };
        }

        public static Location GetLocationFrom(SroEvent @event)
        {
            return new Location()
            {
                Cep = @event.codigo[0],
                City = @event.cidade[0],
                State = @event.uf[0],
                StreetName = @event.local[0]
            };
        }

    }
}
