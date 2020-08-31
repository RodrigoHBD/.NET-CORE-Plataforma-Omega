using Gateway.Controllers.Api.Shipping.Models.Output;
using Gateway.gRPC.Client.ShippingClientProto;
using Google.Protobuf.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Controllers.Api.Shipping.Presenter
{
    public class ForwardingEventsPresenter
    {
        public static List<ForwardingEvent> PresentList(RepeatedField<GrpcForwardingEvent> list) =>
            new ForwardingEventsPresenter(list).GetPresentedList();

        public List<ForwardingEvent> GetPresentedList()
        {
            var list = List.ToList();
            var presented = new List<ForwardingEvent>();

            list.ForEach(@event => 
            {
                presented.Add(GetPresentedFrom(@event));
            });

            return presented;
        }

        public ForwardingEvent GetPresentedFrom(GrpcForwardingEvent @event)
        {
            return new ForwardingEvent()
            {
                Title = @event.Title,
                Description = @event.Description,
                OccurredAt = @event.OccurredAt,
                PackageHasArrived = @event.PackageHasArrived,
                ArrivedAt = @event.ArrivedAt,
                BoundryMessage = @event.BoundryMessage,
                ForwardedFrom = LocationPresenter.Present(@event.ForwardedFrom),
                ForwardedTo = LocationPresenter.Present(@event.ForwardedTo)
            };
        }

        public ForwardingEventsPresenter(RepeatedField<GrpcForwardingEvent> list) => List = list;

        private RepeatedField<GrpcForwardingEvent> List { get; }
    }
}
