using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShippingService.App.Controller.TypeAdapters;
using ShippingService.App.Presenters;
using ShippingService.App.UseCases;
using ShippingService.Correios.Models.Sro;
using ShippingService.gRPC.Server.Protos;

namespace ShippingService.App.Controller
{
    public class Controller
    {
        public static async Task<GrpcVoid> CreateNewShipment(GrpcNewShipmentRequest grpcRequest)
        {
            try
            {
                var request = GrpcNewShipmentRequestAdapter.GetAdapted(grpcRequest);
                await UseCaseOperator.CreateNewShipment(request);
                return GrpcVoid;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static async Task<GrpcVoid> DeleteShipment(GrpcString grpcRequest)
        {
            try
            {
                var id = GrpcStringAdapter.GetFrom(grpcRequest);
                await ShipmentUseCases.Delete.Execute(id);
                return GrpcVoid;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static async Task<GrpcShipment> GetShipmentById(GrpcString grpcRequest)
        {
            try
            {
                var id = GrpcStringAdapter.GetFrom(grpcRequest);
                var shipment = await ShipmentUseCases.Get.ById(id);
                return ShipmentPresenter.Present(shipment);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static async Task<GrpcShipmentEvents> GetShipmentEvents(GrpcString grpcRequest)
        {
            try
            {
                var id = GrpcStringAdapter.GetFrom(grpcRequest);
                var shipment = await ShipmentUseCases.Get.ById(id);
                return ShipmentEventsPresenter.Present(shipment);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static async Task<GrpcShipmentList> SearchShipments(GrpcShipmentSearchRequest grpcRequest)
        {
            try
            {
                var req = GrpcShipmentSearchRequestAdapter.Adapt(grpcRequest);
                var resp = await ShipmentUseCases.Search.Execute(req);
                return ShipmentListPresenter.Present(resp);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static async Task<GrpcVoid> SetShipmentAutoUpdate(GrpcSetAutoUpdateRequest grpcRequest)
        {
            try
            {
                var adapter = new GrpcSetAutoUpdateRequestAdapter(grpcRequest);
                var id = adapter.GetId();
                var toggle = adapter.GetBool();
                await ShipmentUseCases.Set.AutoUpdate(id, toggle);
                return GrpcVoid;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static async Task<GrpcPackage> GetPackageById(GrpcString grpcRequest)
        {
            try
            {
                var id = GrpcStringAdapter.GetFrom(grpcRequest);
                var package = await GetPackage.Execute(id);
                return PackagePresenter.PresentePackage(package);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task<GrpcVoid> RunAutoUpdate()
        {
            try
            {
                await UseCaseOperator.RunShipmentAutoUpdate();
                return GrpcVoid;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task<GrpcVoid> RunAutoUpdateById(GrpcString req)
        {
            try
            {
                var id = GrpcStringAdapter.GetFrom(req);
                await ShipmentUseCaseController.RunAutoUpdateById(id);
                return GrpcVoid;
            }
            catch (Exception e)
            {
                throw e;
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

        public static async Task<GrpcBoolean> GetIsMarketplaceSaleIdRegistered(GrpcString req)
        {
            try
            {
                var id = GrpcStringAdapter.GetFrom(req);
                var isRegistered = await ShipmentUseCases.GetIsMarketplaceSaleIdRegistered(id);
                return new GrpcBoolean() { Value = isRegistered };
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static GrpcVoid GrpcVoid { get; } = new GrpcVoid();

    }
}
