﻿using Gateway.gRPC.Client.MercadoLivreProto;
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

        private static MercadoLivre.MercadoLivreClient Client { get; set; }

        public static void Initialize()
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            var channel = GrpcChannel.ForAddress(UriAddress);
            Client = new MercadoLivre.MercadoLivreClient(channel);
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

    }
}
