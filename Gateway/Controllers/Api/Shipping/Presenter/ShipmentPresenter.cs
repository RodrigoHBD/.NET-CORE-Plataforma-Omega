using Gateway.Controllers.Api.Shipping.Models;
using Gateway.gRPC.Client.ShippingClientProto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Gateway.Controllers.Api.Shipping.Presenter
{
    public class ShipmentPresenter
    {
        public static Shipment Present(GrpcShipment shipment) => 
            new ShipmentPresenter(shipment).GetPresented();

        public static string PresentSerialized(GrpcShipment shipment) =>
            JsonSerializer.Serialize(new ShipmentPresenter(shipment).GetPresented());

        public Shipment GetPresented()
        {
            return new Shipment()
            {
                Id = Shipment.Id,
                PackageId = Shipment.PackageId,
                BoundMarketplace = Shipment.BoundMarketplace,
                MarketplaceAccountId = Shipment.MarketplaceAccountId,
                MarketplaceSaleId = Shipment.MarketplaceSaleId,
                AutoUpdate = Shipment.AutoUpdate,
                CreatedManually = Shipment.CreatedManually,
                ShippingService = Shipment.BoundryImplementation,
                TrackingCode = Shipment.TrackingCode,
                States = GetStates(),
                BoundryMessage = Shipment.BoundryMessage,
                CreatedAt = Shipment.CreatedAt
            };
        }

        public ShipmentPresenter(GrpcShipment shipment)
        {
            Shipment = shipment;
        }

        private GrpcShipment Shipment { get; }

        private ShipmentStates GetStates()
        {
            return new ShipmentStates()
            {
                IsAwaitingForPickUp = Shipment.States.IsAwaitingForPickUp,
                IsBeingTransported = Shipment.States.IsBeingTransported,
                IsDelivered = Shipment.States.IsDelivered,
                IsDeliveredToDestination = Shipment.States.IsDeliveredToDestination,
                IsPosted = Shipment.States.IsPosted,
                IsRejected = Shipment.States.IsRejected
            }; 
        }
    }
}
