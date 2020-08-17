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
                throw HandleException(e);
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
                throw HandleException(e);
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
                throw HandleException(e);
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
                throw HandleException(e);
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
                throw HandleException(e);
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
                throw HandleException(e);
            }
        }

        public override async Task<GrpcStatusResponse> HardDeletePackage(GrpcIdMessage request, ServerCallContext context)
        {
            try
            {
                return await Controller.HardDeletePackage(request);
            }
            catch (Exception e)
            {
                throw HandleException(e);
            }
        }

        public override async Task<GrpcStatusResponse> RunPackageWatcherRoutine(GrpcVoid request, ServerCallContext context)
        {
            try
            {
                return await Controller.RunPackageWatcherRoutine();
            }
            catch (Exception e)
            {
                throw HandleException(e);
            }
        }

        public override async Task<GrpcRoutineStates> GetPackageWatcherRoutineState(GrpcVoid request, ServerCallContext context)
        {
            try
            {
                return await Controller.GetPackageWatcherRoutineState();
            }
            catch (Exception e)
            {
                throw HandleException(e);
            }
        }

        public override async Task<GrpcBooleanMessage> CheckMarketplaceIdIsRegistered(GrpcStringMessage request, ServerCallContext context)
        {
            try
            {
                return await Controller.CheckMarketplaceIdIsRegistered(request);
            }
            catch (Exception e)
            {
                throw HandleException(e);
            }
        }

        public static RpcException HandleException(Exception exception)
        {
            Console.WriteLine($"--> EXCEPTION MESSAGE : {exception.Message}");
            Console.WriteLine($"--> EXCEPTION STACK TRACE : {exception.StackTrace}");
            return new RpcException(new Status(StatusCode.Unknown, exception.Message));
        }

    }
}
