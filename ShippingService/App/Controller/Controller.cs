﻿using System;
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
                return StatusResponsePresenter.Present(true);
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
                return StatusResponsePresenter.Present(true);
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
                return StatusResponsePresenter.Present(true);
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
                return StatusResponsePresenter.Present(true);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task<GrpcPackageData> GetPackageData(GrpcIdMessage grpcRequest)
        {
            try
            {
                var id = grpcRequest.Id;
                var package = await UseCaseOperator.GetPackageData(id);
                return PackagePresenter.PresentePackage(package);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task<GrpcPackageList> SearchPackages(GrpcSearchPackageRequest grpcRequest)
        {
            try
            {
                var request = GrpcSearchPackageReqAdapter.Adapt(grpcRequest);
                var packageList = await UseCaseOperator.SearchPackagesAsync(request);
                return PackageListPresenter.PresentPackageList(packageList);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task<GrpcStatusResponse> RunPackageStatusUpdateRoutine(GrpcIdMessage grpcRequest)
        {
            try
            {
                var id = grpcRequest.Id;
                await UseCaseOperator.RunWatcherRoutine(id);
                return StatusResponsePresenter.Present(true, "Rotina executada com sucesso");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task<GrpcStatusResponse> HardDeletePackage(GrpcIdMessage grpcRequest)
        {
            try
            {
                await UseCaseOperator.HardDeletePackage(grpcRequest.Id);
                return StatusResponsePresenter.Present(true, "Pacote deletado");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}