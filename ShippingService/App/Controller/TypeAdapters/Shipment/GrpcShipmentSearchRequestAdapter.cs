using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShippingService.App.Boundries;
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
                ShippingImplementation = GetShippingImplementation(req.ShippingImplementation),
                DynamicString = GrpcStringFilterAdapter.AdaptFrom(req.DynamicString),
                Pagination = GrpcPaginationAdapter.Adapt(req.Pagination)
            };
        }

        private static ShippingBoundry.Implementation GetShippingImplementation(string implementration)
        {
            if(implementration == "correios")
            {
                return ShippingBoundry.Implementation.Correios;
            }
            else if (implementration == "mercado envios")
            {
                return ShippingBoundry.Implementation.MercadoEnvios;
            }
            else
            {
                return ShippingBoundry.Implementation.Unset;
            }
        }
        
    }
}
