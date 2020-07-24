using Gateway.Controllers.Api.Shipping.Models.Input;
using Gateway.Controllers.Shipping.Input;
using Gateway.gRPC.Client.ShippingClientProto;
using Gateway.gRPC.Client.ShippingTypeAdapters;
using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.gRPC.Client
{
    public class ShippingClient
    {
        private static string UriAddress { get; set; } = "http://localhost:5000";
        private static Shipping.ShippingClient Client { get; set; }

        public static void Initialize()
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            var channel = GrpcChannel.ForAddress(UriAddress);
            Client = new Shipping.ShippingClient(channel);
        }

        public static async Task<GrpcPackageData> GetPackageDataAsync(string id)
        {
            try
            {
                var request = new GrpcIdMessage() { Id = id };
                return await Client.GetPackageDataAsync(request);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task<GrpcPackageList> SearchPackagesAsync(PackageSearch search)
        {
            try
            {
                var request = new GrpcSearchPackageRequest() 
                {
                    TrackingCode = search.TrackingCode,
                    Name = search.Name,
                    DynamicField = search.DynamicString,
                    BeingTransported = BooleanSearchFieldAdapter.Adapt(search.BeingTransported),
                    AwaitingForPickUp = BooleanSearchFieldAdapter.Adapt(search.AwaitingForPickUp),
                    Delivered = BooleanSearchFieldAdapter.Adapt(search.Delivered),
                    Rejected = BooleanSearchFieldAdapter.Adapt(search.Rejected),
                    Pagination = new GrpcPagination()
                    {
                        Limit = search.Pagination.Limit,
                        Offset = search.Pagination.Offset
                    }
                };
                return await Client.SearchPackagesAsync(request);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task<GrpcStatusResponse> CreateNewPackage(NewPackage newPackage)
        {
            try
            {
                var request = new GrpcShipPackageRequest()
                {
                    Name = newPackage.Name,
                    Platform = newPackage.Platform,
                    SaleId = newPackage.SaleId,
                    TrackingCode = newPackage.TrackingCode,
                    Weight = newPackage.Weight,
                    CreatedManually = newPackage.IsManuallyCreated,
                    SetWatcher = newPackage.SetWatcher,
                    InitialLocation = LocationAdapter.Adapt(newPackage.PostingLocation)
                };
                return await Client.ShipPackageAsync(request);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public static async Task<GrpcStatusResponse> DeletePackage(string id)
        {
            try
            {
                var request = new GrpcIdMessage() { Id = id };
                return await Client.HardDeletePackageAsync(request);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static  async Task<GrpcRoutineStates> GetPackageWatcherRoutineState()
        {
            try
            {
                return await Client.GetPackageWatcherRoutineStateAsync(new GrpcVoid());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<GrpcStatusResponse> RunPackageWatcherRoutine()
        {
            try
            {
                return await Client.RunPackageWatcherRoutineAsync(new GrpcVoid());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<GrpcStatusResponse> RunWatcherRoutineOnOnePackage(string id)
        {
            try
            {
                var request = new GrpcIdMessage()
                {
                    Id = id
                };
                return await Client.RunPackageWatcherRoutineManuallyAsync(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
