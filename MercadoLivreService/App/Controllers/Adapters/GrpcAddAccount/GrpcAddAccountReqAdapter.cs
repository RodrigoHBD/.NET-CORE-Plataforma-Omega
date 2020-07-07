using MercadoLivreService.App.Controllers.Implementations;
using MercadoLivreService.App.Models;
using MercadoLivreService.gRPC.Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Controllers.Adapters
{
    public class GrpcAddAccountReqAdapter
    {
        public static IAddAccountRequest Adapt(GrpcAddAccountReq grpcRequest)
        {
            try
            {
                return new AddAccountRequest()
                {
                    Name = grpcRequest.Name,
                    Owner = grpcRequest.Owner,
                    Description = grpcRequest.Description,
                    AuthCode = grpcRequest.AuthCode
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
