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

        public override async Task<GrpcPackageData> GetPackageData(GrpcIdMessage request, ServerCallContext context)
        {
            try
            {
                return await Controller.GetPackageData(request);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override async Task<GrpcPackageList> SearchPackages(GrpcSearchPackageRequest request, ServerCallContext context)
        {
            try
            {
                return await Controller.SearchPackages(request);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override async Task<GrpcStatusResponse> RunPackageWatcherRoutineManually(GrpcIdMessage request, ServerCallContext context)
        {
            try
            {
                return await Controller.RunPackageStatusUpdateRoutine(request);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
