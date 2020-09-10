using ShippingService.App.Models;
using ShippingService.gRPC.Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Presenters
{
    public class ShipmentPresenter
    {
        public static GrpcShipment Present(Shipment shipment) => new ShipmentPresenter(shipment).Present();

        public GrpcShipment Present()
        {
            try
            {
                return new GrpcShipment()
                {
                    Id = Shipment.Id.ToString(),
                    PackageId = Shipment.PackageId,
                    TrackingCode = Shipment.TrackingCode,
                    AutoUpdate = Shipment.AutoUpdate,
                    CreatedManually = Shipment.CreatedManually,
                    States = GetStates(),
                    MarketplaceSaleId = Shipment.MarketplaceData.SaleId,
                    MarketplaceAccountId = Shipment.MarketplaceData.AccountId,
                    BoundryImplementation = GetBoundryImplementationName(),
                    BoundMarketplace = Shipment.MarketplaceData.BoundMarketplace,
                    BoundryMessage = Shipment.BoundryMessage,
                    CreatedAt = Shipment.CreatedEvent.Dates.OccurredAt.ToString()
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ShipmentPresenter(Shipment shipment) => Shipment = shipment;

        private Shipment Shipment { get; }

        private GrpcShipmentStates GetStates()
        {
            var states = new GrpcShipmentStates()
            {
                IsAwaitingForPickUp = Shipment.AwaitingForPickUpEvent.IsSet,
                IsPosted = Shipment.PostedEvent.IsPosted,
                IsDelivered = Shipment.DeliveredEvent.IsDelivered,
                IsDeliveredToDestination = Shipment.DeliveredEvent.IsDeliveredToDestination,
                IsRejected = Shipment.RejectedEvent.IsRejected
            };
            if(Shipment.ForwardingEvents.Count > 0)
            {
                states.IsBeingTransported = !Shipment.ForwardingEvents.First().PackageHasArrived;
            }
            return states;
        }

        private string GetBoundryImplementationName()
        {
            var imp = Shipment.BoundryImplementation;

            if(imp == Boundries.ShippingBoundry.Implementation.Correios)
            {
                return "Correios";
            }
            else if(imp == Boundries.ShippingBoundry.Implementation.MercadoEnvios)
            {
                return "Mercado Envios";
            }
            else
            {
                return "Nenhum";
            }
        }
    }
}
