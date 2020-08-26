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

        public static async Task<GrpcVoid> CreateShipment(GrpcNewShipmentRequest req)
        {
            try
            {
                return await Client.CreateNewShipmentAsync(req);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<GrpcShipment> GetShipmentById(GrpcString req)
        {
            try
            {
                return await Client.GetShipmentByIdAsync(req);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<GrpcVoid> DeleteShipment(GrpcString req)
        {
            try
            {
                return await Client.DeleteShipmentAsync(req);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<GrpcVoid> SetShipmentAutoUpdate(GrpcSetAutoUpdateRequest req)
        {
            try
            {
                return await Client.SetShipmentAutoUpdateAsync(req);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<GrpcShipmentList> SearchShipments(GrpcShipmentSearchRequest req)
        {
            try
            {
                return await Client.SearchShipmentsAsync(req);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<GrpcVoid> RunAutoUpdate(GrpcVoid req)
        {
            try
            {
                return await Client.RunAutoUpdateAsync(req);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<GrpcVoid> RunAutoUpdateById(GrpcString req)
        {
            try
            {
                return await Client.RunAutoUpdateByIdAsync(req);
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
                return await Client.GetIsMarketplaceSaleIdRegisteredAsync(req);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
