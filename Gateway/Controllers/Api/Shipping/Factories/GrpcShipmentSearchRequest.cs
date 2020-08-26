using Gateway.Controllers.Shipping.Input;
using Gateway.gRPC.Client.ShippingClientProto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Controllers.Api.Shipping.Factories
{
    public class GrpcShipmentSearchRequestFactory
    {
        public static GrpcShipmentSearchRequest GetFrom(ShipmentSearch search) =>
            new GrpcShipmentSearchRequestFactory(search).Get();

        public GrpcShipmentSearchRequest Get()
        {
            return new GrpcShipmentSearchRequest()
            {
                IsAwaitingForPickUp = GrpcBooleanFilterFactory.GetFrom(Search.AwaitingForPickUp),
                IsDelivered = GrpcBooleanFilterFactory.GetFrom(Search.Delivered),
                IsPosted = GrpcBooleanFilterFactory.GetFrom(Search.Posted),
                IsRejected = GrpcBooleanFilterFactory.GetFrom(Search.Rejected),
                IsDeliveredToDestination = GrpcBooleanFilterFactory.GetFrom(Search.DeliveredToDestination),
                DynamicString = GrpcStringFilterFactory.GetFrom(Search.DynamicString),
                Pagination = PaginationFactory.GetFrom(Search.Pagination),
                AutoUpdate = new GrpcBooleanFilter(),
                BoundMarketplace = new GrpcStringFilter(),
                Sorting = 1,
                IsBeingTransported = new GrpcBooleanFilter()
            };
        }

        public GrpcShipmentSearchRequestFactory(ShipmentSearch search) => Search = search;

        private ShipmentSearch Search { get; }
    }
}
