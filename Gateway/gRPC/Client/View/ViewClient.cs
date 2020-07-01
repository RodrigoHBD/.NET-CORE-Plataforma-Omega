using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gateway.gRPC.Client.ViewClientProtos;
using Grpc.Net.Client;

namespace Gateway.gRPC.Client
{
    public static class ViewClient
    {
        //private static 
        private static string UriAddress { get; set; } = "http://localhost:5005";
        private static View.ViewClient Client { get; set; }
        public static void Initialize()
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            var channel = GrpcChannel.ForAddress(UriAddress);
            Client = new View.ViewClient(channel);
        }

        public static async Task<GrpcViewAsString> GetViewAsync(GrpcGetViewRequest request)
        {
            try
            {
                return await Client.GetViewAsync(request);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task<GrpcViewAsString> GetStaticFileAsync(GrpcGetStaticFileRequest request)
        {
            try
            {
                return await Client.GetStaticFileAsync(request);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
