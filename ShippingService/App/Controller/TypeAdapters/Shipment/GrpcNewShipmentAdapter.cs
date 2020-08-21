using ShippingService.App.Boundries;
using ShippingService.App.Models.Input;
using ShippingService.gRPC.Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Controller.TypeAdapters
{
    public class GrpcNewShipmentRequestAdapter
    {
        public static NewShipmentRequest GetAdapted(GrpcNewShipmentRequest req) =>
            new GrpcNewShipmentRequestAdapter(req).GetAdapted();

        public NewShipmentRequest GetAdapted()
        {
            return new NewShipmentRequest()
            {
                TrackingCode = GetTrackingCode(),
                BoundMarketplace = GetBoundMarketplace(),
                ShippingImplementation = GetShippingImplementation(),
                MarketplaceAccountId = GetMarketplaceAccountId(),
                MarketplaceSaleId = GetMarketplaceSaleId(),
                SetAutoUpdate = GetSetAutoUpdate(),
                PackageData = GrpcNewPackageRequestAdapter.GetAdapted(Request.PackageData)
            };
        }

        public GrpcNewShipmentRequestAdapter(GrpcNewShipmentRequest req)
        {
            Request = req;
        }

        private GrpcNewShipmentRequest Request { get; }

        private string GetTrackingCode()
        {
            return Request.TrackingCode;
        }

        private string GetBoundMarketplace()
        {
            return Request.BoundMarketplace;
        }

        private ShippingBoundry.Implementation GetShippingImplementation()
        {
            return ShippingBoundry.Implementation.Correios;
        }

        private string GetMarketplaceAccountId()
        {
            return Request.MarketplaceAccountId;
        }

        private string GetMarketplaceSaleId()
        {
            return Request.MarketplaceSaleId;
        }

        private bool GetSetAutoUpdate()
        {
            return Request.SetAutoUpdate;
        }

    }
}
