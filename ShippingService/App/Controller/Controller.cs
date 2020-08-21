using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShippingService.App.Controller.TypeAdapters;
using ShippingService.App.Presenters;
using ShippingService.App.TypeAdapters;
using ShippingService.App.UseCases;
using ShippingService.gRPC.Server.Protos;

namespace ShippingService.App.Controller
{
    public class Controller
    {
        public static async Task<GrpcStatusResponse> CreateNewShipment(GrpcNewShipmentRequest grpcRequest)
        {
            try
            {
                var request = GrpcNewShipmentRequestAdapter.GetAdapted(grpcRequest);
                await UseCaseOperator.CreateNewShipment(request);
                return StatusResponsePresenter.Present(true);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static async Task<GrpcStatusResponse> SetShipmentAutoUpdate(GrpcSetBoolByIdRequest grpcRequest)
        {
            try
            {
                return new GrpcStatusResponse();
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
                return new GrpcPackageList();
            }
            catch (Exception e)
            {
                throw;
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

        public static async Task<GrpcStatusResponse> RunPackageWatcherRoutine()
        {
            try
            {
                RoutineScheduler.RunRoutine("Package Watcher");
                return StatusResponsePresenter.Present(true, "Rotina executada com sucesso");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<GrpcStatusResponse> PauseRoutine(GrpcIdMessage request)
        {
            try
            {
                RoutineScheduler.PauseRoutine(request.Id);
                return StatusResponsePresenter.Present(true, "Rotina executada com sucesso");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<GrpcStatusResponse> ResumeRoutine(GrpcIdMessage request)
        {
            try
            {
                RoutineScheduler.ResumeRoutine(request.Id);
                return StatusResponsePresenter.Present(true, "Rotina executada com sucesso");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<GrpcRoutineStates> GetPackageWatcherRoutineState()
        {
            try
            {
                var states = RoutineScheduler.GetRoutineStates("Package Watcher");
                var dates = RoutineScheduler.GetRoutineDates("Package Watcher");
                return RoutineStatePresenter.Present(dates, states);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<GrpcBooleanMessage> CheckMarketplaceIdIsRegistered(GrpcStringMessage grpcRequest)
        {
            try
            {
                
                return new GrpcBooleanMessage() { Value = true };
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
