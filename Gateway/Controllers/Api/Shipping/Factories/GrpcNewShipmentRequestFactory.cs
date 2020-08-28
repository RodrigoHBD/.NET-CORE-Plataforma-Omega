using Gateway.Controllers.Api.Shipping.Models.Input;
using Gateway.gRPC.Client.ShippingClientProto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Controllers.Api.Shipping.Factories
{
    public class GrpcNewShipmentRequestFactory
    {
        public static GrpcNewShipmentRequest GetFrom(NewShipment shipment) =>
            new GrpcNewShipmentRequestFactory(shipment).Get();

        public GrpcNewShipmentRequest Get()
        {
            return new GrpcNewShipmentRequest()
            {
                TrackingCode = Req.TrackingCode,
                BoundMarketplace = Req.BoundMarketplace,
                MarketplaceAccountId = Req.MarketpalceAccountId,
                MarketplaceSaleId = Req.MarketpalceSaleId,
                ShippingImplementation = Req.ShippingService,
                SetAutoUpdate = Req.SetAutoUpdate,
                SetCreatedManually = Req.SetCreatedManually,
                PackageData = GetPackageData()
            };
        }

        public GrpcNewShipmentRequestFactory(NewShipment req) => Req = req;

        private NewShipment Req { get; }

        private GrpcNewPackageRequest GetPackageData()
        {
            var packageData = new GrpcNewPackageRequest()
            {
                Name = Req.Package.Name,
                WeightInGrams = Req.Package.WeightInGrams,
                HeightInMm = Req.Package.HeightInMm,
                WidthInMm = Req.Package.WidthInMm,
                LengthInMm = Req.Package.LengthInMm,
            };
            Req.Package.Content.ToList().ForEach(id => { packageData.ContentIds.Add(id); });
            return packageData;
        }
    }
}
