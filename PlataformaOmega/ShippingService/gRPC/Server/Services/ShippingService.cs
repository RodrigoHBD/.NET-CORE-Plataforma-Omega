using Grpc.Core;
using ShippingService.App.Controller;
using ShippingService.gRPC.Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.gRPC.Server.Services
{
    public class ShippingServiceImplementation : Shipping.ShippingBase
    {
        public override async Task<GrpcStatusResponse> ShipPackage(GrpcShipPackageRequest request, ServerCallContext context)
        {
            try
            {
                return await Controller.ShipNewPackage(request);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override async Task<GrpcStatusResponse> SetPackagePosted(GrpcUpdatePackageRequest request, ServerCallContext context)
        {
            try
            {
                return await Controller.SetPackageToPosted(request);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override async Task<GrpcStatusResponse> WatchPackage(GrpcWatchPackageRequest request, ServerCallContext context)
        {
            try
            {
                return await Controller.WatchPackage(request);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
