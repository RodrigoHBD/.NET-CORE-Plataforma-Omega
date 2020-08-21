using ShippingService.App.Boundries;
using ShippingService.App.Models;
using ShippingService.App.Models.Input;
using ShippingService.App.Models.ShipmentEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Factories
{
    public class ShipmentFactory
    {
        public static Shipment CreateShipment(NewShipmentRequest request)
        {
            var factory = new ShipmentFactory(request);
            return factory.GetShipment();
        }

        public Shipment GetShipment()
        {
            return new Shipment()
            {
                TrackingCode = GetTrackingCode(),
                AutoUpdate = GetAutoUpdate(),
                BoundryImplementation = GetBoundryImplementation(),
                MarketplaceData = GetMarketplaceData(),
                PackageId = GetPackageId(),
                CreatedEvent = GetCreatedEvent()
            };
        }

        public void SetPackageId(string id)
        {
            PackageId = id;
        }

        public ShipmentFactory(NewShipmentRequest request)
        {
            Request = request;
        }

        private NewShipmentRequest Request { get; }

        private string PackageId { get; set; } = null;

        private string GetPackageId()
        {
            return PackageId;
        }

        private string GetTrackingCode()
        {
            return Request.TrackingCode;
        }

        private bool GetAutoUpdate()
        {
            return Request.SetAutoUpdate;
        }

        private ShippingBoundry.Implementation GetBoundryImplementation()
        {
            return Request.ShippingImplementation;
        }

        private CreatedEvent GetCreatedEvent()
        {
            var _event = new CreatedEvent();
            _event.SetOccuredAtToNow();
            return _event;
        }

        private ShipmentMarketplaceData GetMarketplaceData()
        {
            return new ShipmentMarketplaceData()
            {
                AccountId = Request.MarketplaceAccountId,
                SaleId = Request.MarketplaceSaleId,
                BoundMarketplace = Request.BoundMarketplace
            };
        }
    }
}
