using ShippingService.App.Boundries.MailerTypeAdapters.Output;
using ShippingService.App.Entities;
using ShippingService.App.Models;
using ShippingService.App.Models.ShipmentEvents;
using ShippingService.Correios.Models.Sro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Boundries.Shipping
{
    public class ForwardingEventFactory
    {
        public List<ForwardingEvent> GetEventList()
        {
            SetJsonForwardingEvents();
            SetForwardingEvents();
            return ForwardingEvents;
        }

        public ForwardingEventFactory(SroJsonResponse json)
        {
            Json = json;
        }

        private SroJsonResponse Json { get; }

        private List<SroEvent> JsonForwardingEvents { get; set; } = new List<SroEvent>();

        private List<ForwardingEvent> ForwardingEvents { get; set; } = new List<ForwardingEvent>();

        private bool GetIsForwardedAtLeastOnce()
        {
            var isForwarded = false;

            Json.evento.ForEach(evento =>
            {
                var forwardedDO = evento.tipo[0] == "DO" && (evento.status[0] == "01" || evento.status[0] == "02");

                var forwardedFC = evento.tipo[0] == "FC" && (evento.status[0] == "12" || evento.status[0] == "19" ||
                evento.status[0] == "27" || evento.status[0] == "29" || evento.status[0] == "32" ||
                evento.status[0] == "33" || evento.status[0] == "34" || evento.status[0] == "35" ||
                evento.status[0] == "37");

                // saiu para entrega
                var forwardedOEC = evento.tipo[0] == "OEC" && (evento.status[0] == "01" || evento.status[0] == "09");

                var forwardedPAR = evento.tipo[0] == "PAR" && (evento.status[0] == "21" || evento.status[0] == "22" ||
                evento.status[0] == "28");

                var forwardedRO = evento.tipo[0] == "RO" && (evento.status[0] == "01");

                if (forwardedDO || forwardedFC || forwardedOEC || forwardedPAR || forwardedRO)
                {
                    isForwarded = true;
                }
            });

            return isForwarded;
        }

        private bool GetIsForwardingEvent(SroEvent evento)
        {
            var forwardedDO = evento.tipo[0] == "DO" && (evento.status[0] == "01" || evento.status[0] == "02");

            var forwardedFC = evento.tipo[0] == "FC" && (evento.status[0] == "12" || evento.status[0] == "19" ||
            evento.status[0] == "27" || evento.status[0] == "29" || evento.status[0] == "32" ||
            evento.status[0] == "33" || evento.status[0] == "34" || evento.status[0] == "35" ||
            evento.status[0] == "37");

            // saiu para entrega
            var forwardedOEC = evento.tipo[0] == "OEC" && (evento.status[0] == "01" || evento.status[0] == "09");

            var forwardedPAR = evento.tipo[0] == "PAR" && (evento.status[0] == "21" || evento.status[0] == "22" ||
            evento.status[0] == "28");

            var forwardedRO = evento.tipo[0] == "RO" && (evento.status[0] == "01");

            if (forwardedDO || forwardedFC || forwardedOEC || forwardedPAR || forwardedRO)
            {
                return true;
            }
            return false;
        }

        private bool GetIsTheNotArrivedEvent(SroEvent evento)
        {
            try
            {
                var isTheEventBDE = evento.tipo[0] == "BDE" && (evento.status[0] == "09" || evento.status[0] == "69");
                var isTheEventBDI = evento.tipo[0] == "BDI" && (evento.status[0] == "09" || evento.status[0] == "69");
                var isTheEventBDR = evento.tipo[0] == "BDR" && (evento.status[0] == "09" || evento.status[0] == "69");
                var isTheEvent = isTheEventBDE || isTheEventBDI || isTheEventBDR;
                return isTheEvent;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void SetJsonForwardingEvents()
        {
            Json.evento.ForEach(@event =>
            {
                var isForwardingEvent = GetIsForwardingEvent(@event);
                if (isForwardingEvent)
                {
                    JsonForwardingEvents.Add(@event);
                }
            });
        }

        private void SetForwardingEvents()
        {
            JsonForwardingEvents.ForEach(@event =>
            {
                var isTheNotArrivedEvent = GetIsTheNotArrivedEvent(@event);

                if (!isTheNotArrivedEvent)
                {
                    ForwardingEvents.Add(GetForwardingEventFrom(@event));
                }
            });
        }

        private bool GetIsDestinationAvailable(SroEvent @event)
        {
            if(@event.destino.Count > 0)
            {
                return true;
            }
            return false;
        }

        private bool GetIsPackageArrivedFrom(SroEvent @event)
        {
            var destination = new Location();
            var isDestinationAvailable = GetIsDestinationAvailable(@event);
            var eventLocationsList = new List<Location>();
            var isArrived = false;

            if (isDestinationAvailable)
            {
                destination = SroResponseJsonAdapter.GetForwarededToLocationFrom(@event);
            }
            else
            {
                destination = SroResponseJsonAdapter.GetLocationFrom(@event);
            }

            Json.evento.ForEach(_event =>
            {
                var eventLocation = SroResponseJsonAdapter.GetLocationFrom(_event);
                var locationsMatch = LocationEntity.CompareLocationsBool(destination, eventLocation);
 
                if (locationsMatch)
                {
                    isArrived = true;
                }
            });

            return isArrived;
        }

        private DateTime GetArrivalDateTimeFrom(Location location)
        {
            var date = new DateTime();
            var events = Json.evento;

            for (var i = events.Count -1; i >= 0; i--)
            {
                var @event = events[i];
                var eventLocation = SroResponseJsonAdapter.GetLocationFrom(@event);
                var locationsMatch = LocationEntity.CompareLocationsBool(eventLocation, location);
                if (locationsMatch)
                {
                    date = SroResponseJsonAdapter.GetDateTimeFrom(@event);
                }
            }
            return date;
        }

        private Location GetForwardedToLocationFrom(SroEvent @event)
        {
            var destinationAvailable = GetIsDestinationAvailable(@event);

            if (destinationAvailable)
            {
                return SroResponseJsonAdapter.GetForwarededToLocationFrom(@event);
            }
            return SroResponseJsonAdapter.GetLocationFrom(@event);
        }

        private string GetBoundryMessageFrom(SroEvent @event)
        {
            return @event.descricao[0];
        }

        private ForwardingEvent GetForwardingEventFrom(SroEvent @event)
        {
            var _event = new ForwardingEvent()
            {
                Dates = new ShipmentEventDates(),
                Locations = new ForwardedToLocations()
            };

            _event.PackageHasArrived = GetIsPackageArrivedFrom(@event);
            _event.BoundryMessage = GetBoundryMessageFrom(@event);
            _event.Dates.OccurredAt = SroResponseJsonAdapter.GetDateTimeFrom(@event);
            _event.Locations.ForwardedFrom = SroResponseJsonAdapter.GetLocationFrom(@event);
            _event.Locations.ForwardedTo = GetForwardedToLocationFrom(@event);
            _event.ArrivedAt = GetArrivalDateTimeFrom(_event.Locations.ForwardedTo);

            return _event;
        }

    }
}
