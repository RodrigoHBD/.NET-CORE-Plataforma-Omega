using Grpc.Core;
using MercadoLivreService.App.Controllers;
using MercadoLivreService.gRPC.Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.gRPC.Server
{
    public class ServiceImplementation : MercadoLivre.MercadoLivreBase
    {
        public override async Task<GrpcStatusResponse> AddNewAccount(GrpcAddAccountReq request, ServerCallContext context)
        {
            try
            {
                return await MainController.AddAccount(request);
            }
            catch (Exception e)
            {
                throw HandleException(e);
            }
        }

        public override async Task<GrpcStringResponse> GetAppId(GrpcVoid request, ServerCallContext context)
        {
            try
            {
                return await MainController.GetAppId();
            }
            catch (Exception e)
            {
                throw HandleException(e);
            }
        }

        public override async Task<GrpcStringResponse> GetAppToken(GrpcVoid request, ServerCallContext context)
        {
            try
            {
                return await MainController.GetAppToken();
            }
            catch (Exception e)
            {
                throw HandleException(e);
            }
        }

        private RpcException HandleException(Exception e)
        {
            Console.WriteLine(e);
            return new RpcException(new Status(StatusCode.Internal, e.Message));
        }

    }
}
