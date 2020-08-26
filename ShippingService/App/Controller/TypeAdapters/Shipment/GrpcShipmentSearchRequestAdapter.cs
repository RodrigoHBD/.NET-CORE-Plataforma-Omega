using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShippingService.App.Models.Input;
using ShippingService.gRPC.Server.Protos;

namespace ShippingService.App.Controller.TypeAdapters
{
    public class GrpcShipmentSearchRequestAdapter
    {
        public static ShipmentSearch Adapt(GrpcShipmentSearchRequest req)
        {
            return new ShipmentSearch()
            {
                AutoUpdate = GrpcBooleanFilterAdapter.AdaptFrom(req.AutoUpdate),
                IsAwaitingForPickUp = GrpcBooleanFilterAdapter.AdaptFrom(req.IsAwaitingForPickUp),
                IsBeingTransported = GrpcBooleanFilterAdapter.AdaptFrom(req.IsBeingTransported),
                IsDelivered = GrpcBooleanFilterAdapter.AdaptFrom(req.IsDelivered),
                IsDeliveredToDestination = GrpcBooleanFilterAdapter.AdaptFrom(req.IsDeliveredToDestination),
                IsPosted = GrpcBooleanFilterAdapter.AdaptFrom(req.IsPosted),
                IsRejected = GrpcBooleanFilterAdapter.AdaptFrom(req.IsRejected),
                BoundMarketplace = GrpcStringFilterAdapter.AdaptFrom(req.BoundMarketplace),
                DynamicString = GrpcStringFilterAdapter.AdaptFrom(req.DynamicString),
                Pagination = GrpcPaginationAdapter.Adapt(req.Pagination)
            };
        }

        
    }
}
