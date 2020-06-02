using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using SalesService.App.Controller;
using SalesService.gRPC.Server.Protos;

namespace SalesService.gRPC.Server.Services
{
    public class SalesServiceImplementation : Sale.SaleBase
    {
        public override async Task<GrpcStatusResponse> RegisterSale(GrpcRegisteSaleRequest request, ServerCallContext context)
        {
            try
            {
                return await Controller.RegisterNewSale(request);
            }
            catch (Exception e)
            {
                throw HandleException(e);
            }
        }

        public static RpcException HandleException(Exception e)
        {
            return new RpcException(new Status(StatusCode.Internal, e.Message));
        }
    }
}
