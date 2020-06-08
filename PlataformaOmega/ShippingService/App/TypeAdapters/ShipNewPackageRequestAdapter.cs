using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShippingService.App.Models;
using ShippingService.App.Models.Input;
using ShippingService.gRPC.Server.Protos;

namespace ShippingService.App.TypeAdapters
{
    public class ShipNewPackageRequestAdapter
    {
        public static IShipPackageRequest AdaptFromGrpc(GrpcShipPackageRequest grpcRequest)
        {
            try
            {
                return new ShipPackageRequest()
                {
                    ProductId = grpcRequest.ProductId,
                    Name = grpcRequest.Name,
                    TrackingCode = grpcRequest.TrackingCode
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }

    public class ShipPackageRequest : IShipPackageRequest
    {
        public string Name { get; set; }

        public string ProductId { get; set; }

        public string TrackingCode { get; set; }

        public Location PackageInitialLocation { get; set; }
    }
}
