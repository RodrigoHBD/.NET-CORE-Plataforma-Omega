using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.gRPC.Client.MercadoLivre
{
    public class MercadoLivreClient : MercadoLivreGrpc.MercadoLivreGrpcClient
    {
        private static string UriAddress { get; set; } = "http://localhost:5004";

        private static MercadoLivreGrpc.MercadoLivreGrpcClient Client { get; set; }

        public static void Initialize()
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            var channel = GrpcChannel.ForAddress(UriAddress);
            Client = new MercadoLivreGrpc.MercadoLivreGrpcClient(channel);
        }

        public static async Task<GrpcVoid> SendMessage(GrpcSendMessageReq req)
        {
            try
            {
                return await Client.SendMessageAsync(req);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
