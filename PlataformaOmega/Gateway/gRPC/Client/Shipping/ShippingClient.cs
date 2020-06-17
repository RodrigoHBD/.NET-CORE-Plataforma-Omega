using Gateway.gRPC.Client.ShippingClientProto;
using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.gRPC.Client
{
    public class ShippingClient
    {
        private static string UriAddress { get; set; } = "http://localhost:5005";
        private static Shipping.ShippingClient Client { get; set; }

        public static void Initialize()
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            var channel = GrpcChannel.ForAddress(UriAddress);
            Client = new Shipping.ShippingClient(channel);
        }

        public static async Task<GrpcPackageData> GetPackageDataAsync(GrpcIdMessage request)
        {
            try
            {
                return await Client.GetPackageDataAsync(request);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
