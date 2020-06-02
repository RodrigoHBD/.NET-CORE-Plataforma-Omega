using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShippingService.App.Presenters;
using ShippingService.App.TypeAdapters;
using ShippingService.App.UseCases;
using ShippingService.gRPC.Server.Protos;

namespace ShippingService.App.Controller
{
    public class Controller
    {
        public static async Task<GrpcStatusResponse> ShipNewPackage(GrpcShipPackageRequest grpcRequest)
        {
            try
            {
                var request = ShipNewPackageRequestAdapter.AdaptFromGrpc(grpcRequest);
                await UseCaseOperator.ShipNewPackage(request);
                return Presenter.PresentStatusResponse(true);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task<GrpcStatusResponse> SetPackageToPosted(GrpcUpdatePackageRequest grpcRequest)
        {
            try
            {
                var id = GrpcUpdatePackageAdapter.GetId(grpcRequest);
                await UseCaseOperator.SetPackagePosted(id);
                return Presenter.PresentStatusResponse(true);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task<GrpcStatusResponse> SetPackageToDelivered(GrpcUpdatePackageRequest grpcRequest)
        {
            try
            {
                var id = GrpcUpdatePackageAdapter.GetId(grpcRequest);
                await UseCaseOperator.SetPackageDelivered(id);
                return Presenter.PresentStatusResponse(true);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task<GrpcStatusResponse> WatchPackage(GrpcWatchPackageRequest grpcRequest)
        {
            try
            {
                var id = GrpcWatchPackageRequestAdapter.GetId(grpcRequest);
                await UseCaseOperator.WatchPackage(id);
                return Presenter.PresentStatusResponse(true);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
