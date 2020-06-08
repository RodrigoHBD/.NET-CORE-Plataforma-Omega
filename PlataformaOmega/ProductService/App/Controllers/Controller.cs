using ProductService.App.TypeAdapters.GrpcNewPhysicalProductRequest;
using ProductService.App.UseCases;
using ProductService.gRPC.Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.Controllers
{
    public class Controller
    {
        public static async Task CreateNewPhysicalProduct(GrpcNewPhysicalProduct grpcRequest)
        {
            try
            {
                var request = GrpcNewPhysicalRequestAdapter.Adapt(grpcRequest);
                await UseCaseOperator.CreateNewPhysicalProductAsync(request);
            }
            catch (Exception e)
            {
                throw e;
            }
        }



    }
}
