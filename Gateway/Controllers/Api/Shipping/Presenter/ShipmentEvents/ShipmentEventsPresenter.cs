using Gateway.Controllers.Api.Shipping.Models.Output;
using Gateway.gRPC.Client.ShippingClientProto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Gateway.Controllers.Api.Shipping.Presenter
{
    public class ShipmentEventsPresenter
    {
        public static ShipmentEvents Present(GrpcShipmentEvents events) =>
            new ShipmentEventsPresenter(events).GetPresented();

        public static string PresentSerialized(GrpcShipmentEvents events) =>
            JsonSerializer.Serialize(Present(events));

        public ShipmentEvents GetPresented()
        {
            return new ShipmentEvents()
            {
                CreatedEvent = GetCreatedEvent(),
                PostedEvent = GetPostedEvent(),
                AwaitingForPickUpEvent = GetAwaitingForPickUpEvent(),
                RejectedEvent = GetRejcetdEvent(),
                DeliveredEvent = GetDeliveredEvent(),
                ForwardingEvents = ForwardingEventsPresenter.PresentList(Events.ForwardingEvents)
            };
        }

        public ShipmentEventsPresenter(GrpcShipmentEvents events) => Events = events;

        private GrpcShipmentEvents Events { get; }

        private CreatedEvent GetCreatedEvent()
        {
            var @event = Events.CreatedEvent;
            return new CreatedEvent()
            {
                Title = @event.Title,
                Description = @event.Description,
                OccurredAt = @event.OccurredAt
            };
        }

        private PostedEvent GetPostedEvent()
        {
            var @event = Events.PostedEvent;
            return new PostedEvent()
            {
                Title = @event.Title,
                Description = @event.Description,
                OccurredAt = @event.OccurredAt,
                IsPosted = @event.IsPosted
            };
        }

        private AwaitingForPickUpEvent GetAwaitingForPickUpEvent()
        {
            var @event = Events.AwaitingForPickUpEvent;
            return new AwaitingForPickUpEvent()
            {
                Title = @event.Title,
                Description = @event.Description,
                OccurredAt = @event.OccurredAt,
                IsSet = @event.IsSet,
                Location = LocationPresenter.Present(@event.Location)
            };
        }

        private RejectedEvent GetRejcetdEvent()
        {
            var @event = Events.RejectedEvent;
            return new RejectedEvent()
            {
                Title = @event.Title,
                Description = @event.Description,
                OccurredAt = @event.OccurredAt,
                IsRejected = @event.IsRejected
            };
        }

        private DeliveredEvent GetDeliveredEvent()
        {
            var @event = Events.DeliveredEvent;
            return new DeliveredEvent()
            {
                Title = @event.Title,
                Description = @event.Description,
                OccurredAt = @event.OccurredAt,
                IsDelivered = @event.IsDelivered,
                IsDeliveredToDestination = @event.IsDeliveredToDestination
            };
        }

    }
}
