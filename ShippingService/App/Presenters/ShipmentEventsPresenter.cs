using Google.Protobuf.Collections;
using ShippingService.App.Models;
using ShippingService.App.Models.ShipmentEvents;
using ShippingService.gRPC.Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Presenters
{
    public class ShipmentEventsPresenter
    {
        public static GrpcShipmentEvents Present(Shipment shipment) =>
            new ShipmentEventsPresenter(shipment).GetPresented();

        public GrpcShipmentEvents GetPresented()
        {
            var presented = new GrpcShipmentEvents()
            {
                CreatedEvent = GetCreatedEvent(),
                PostedEvent = GetPostedEvent(),
                AwaitingForPickUpEvent = GetAwaitingForPickUpEvent(),
                RejectedEvent = GetRejectedEvent(),
                DeliveredEvent = GetDeliveredEvent()
            };
            SetForwardingEvents(presented.ForwardingEvents);
            return presented;
        }

        public ShipmentEventsPresenter(Shipment shipment) => Shipment = shipment;

        private Shipment Shipment { get; }

        private GrpcCreatedEvent GetCreatedEvent()
        {
            var @event = Shipment.CreatedEvent;
            return new GrpcCreatedEvent()
            {
                Title = @event.Title,
                Description = @event.Description,
                OccurredAt = @event.Dates.OccurredAt.ToLongDateString()
            };
        }

        private GrpcPostedEvent GetPostedEvent()
        {
            var @event = Shipment.PostedEvent;
            return new GrpcPostedEvent()
            {
                Title = @event.Title,
                Description = @event.Description,
                OccurredAt = @event.Dates.OccurredAt.ToLongDateString(),
                IsPosted = @event.IsPosted
            };
        }

        private GrpcAwaitingForPickUpEvent GetAwaitingForPickUpEvent()
        {
            var @event = Shipment.AwaitingForPickUpEvent;
            return new GrpcAwaitingForPickUpEvent()
            {
                Title = @event.Title,
                Description = @event.Description,
                OccurredAt = @event.Dates.OccurredAt.ToLongDateString(),
                IsSet = @event.IsSet,
                Location = LocationPresenter.PresentLocation(@event.Location)
            };
        }

        private GrpcRejectedEvent GetRejectedEvent()
        {
            var @event = Shipment.RejectedEvent;
            return new GrpcRejectedEvent()
            {
                Title = @event.Title,
                Description = @event.Description,
                OccurredAt = @event.Dates.OccurredAt.ToLongDateString(),
                IsRejected = @event.IsRejected,
            };
        }

        private GrpcDeliveredEvent GetDeliveredEvent()
        {
            var @event = Shipment.DeliveredEvent;
            return new GrpcDeliveredEvent()
            {
                Title = @event.Title,
                Description = @event.Description,
                OccurredAt = @event.Dates.OccurredAt.ToLongDateString(),
                IsDelivered = @event.IsDelivered,
                IsDeliveredToDestination = @event.IsDeliveredToDestination
            };
        }

        private  void SetForwardingEvents(RepeatedField<GrpcForwardingEvent> list)
        {
            var @events = Shipment.ForwardingEvents;

            events.ForEach(@event => 
            {
                list.Add(GetGrpcForwardingEventFrom(@event)); 
            });
        }

        private GrpcForwardingEvent GetGrpcForwardingEventFrom(ForwardingEvent @event)
        {
            return new GrpcForwardingEvent()
            {
                Title = @event.Title,
                Description = @event.Description,
                OccurredAt = @event.Dates.OccurredAt.ToLongDateString(),
                PackageHasArrived = @event.PackageHasArrived,
                ArrivedAt = @event.ArrivedAt.ToLongDateString(),
                BoundryMessage = @event.BoundryMessage,
                ForwardedFrom = LocationPresenter.PresentLocation(@event.Locations.ForwardedFrom),
                ForwardedTo = LocationPresenter.PresentLocation(@event.Locations.ForwardedTo)
            };
        }
    }
}
