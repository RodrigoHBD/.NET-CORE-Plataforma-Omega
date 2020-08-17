using Gateway.gRPC.Client.MercadoLivreProto;
using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Gateway.gRPC.Client.

namespace Gateway.gRPC.Client
{
    public class MercadoLivreClient
    {
        private static string UriAddress { get; set; } = "http://localhost:5004";

        private static MercadoLivreGrpc.MercadoLivreGrpcClient Client { get; set; }

        public static void Initialize()
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            var channel = GrpcChannel.ForAddress(UriAddress);
            Client = new MercadoLivreGrpc.MercadoLivreGrpcClient(channel);
        }

        public static async Task<GrpcAccountList> SearchAccounts(GrpcSearchAccountsReq request)
        {
            try
            {
                return await Client.SearchAccountsAsync(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<GrpcStringResponse> GetAppId()
        {
            try
            {
                var request = new GrpcVoid();
                return await Client.GetAppIdAsync(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<GrpcStatusResponse> AddAccount(GrpcAddAccountReq req)
        {
            try
            {
                return await Client.AddNewAccountAsync(req);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<GrpcOrder> GetOrderDetail(GrpcGetOrderDetailReq request)
        {
            try
            {
                return await Client.GetOrderDetailAsync(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<GrpcShipmentDetail> GetShipmentDetail(GrpcGetShipmentDetailReq request)
        {
            try
            {
                return await Client.GetShipmentDetailAsync(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<GrpcAccount> GetAccountByMarketplaceId(GrpcGetByIdReq request)
        {
            try
            {
                return await Client.GetAccountByMarketplaceIdAsync(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
