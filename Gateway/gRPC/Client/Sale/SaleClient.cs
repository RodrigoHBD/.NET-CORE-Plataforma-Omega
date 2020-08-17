using Gateway.gRPC.Client.SaleClientProto;
using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.gRPC.Client.Sale
{
    public class SaleClient
    {
        private static string UriAddress { get; set; } = "http://localhost:5002";

        private static GrpcSaleService.GrpcSaleServiceClient Client { get; set; }

        public static void Initialize()
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            var channel = GrpcChannel.ForAddress(UriAddress);
            Client = new GrpcSaleService.GrpcSaleServiceClient(channel);
        }

        public static async Task<GrpcStatusResponse> RegisterNewSale(GrpcRegisteSaleRequest request)
        {
            try
            {
                return await Client.RegisterSaleAsync(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<GrpcSale> GetByMarketplaceId(GrpcStringMessage request)
        {
            try
            {
                return await Client.GetSaleByMarketplaceIdAsync(request);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
