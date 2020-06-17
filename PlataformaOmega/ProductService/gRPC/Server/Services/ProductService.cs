using Grpc.Core;
using ProductService.App.Controllers;
using ProductService.gRPC.Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.gRPC.Server.Services
{
    public class ProductServiceImplementataion : Product.ProductBase
    {
        public override async Task<GrpcResponseStatus> CreateNewPhysicalProduct(GrpcNewPhysicalProduct request, ServerCallContext context)
        {
            try
            {
                await Controller.CreateNewPhysicalProduct(request);
                return new GrpcResponseStatus();
            }
            catch (Exception e)
            {
                throw HandleException(e);
            }

        }

        public override async Task<GrpcProduct> GetProductData(GrpcIdMessage request, ServerCallContext context)
        {
            try
            {
                return await Controller.GetProductData(request);
            }
            catch (Exception e)
            {
                throw HandleException(e);
            }
        }

        public static RpcException HandleException(Exception exception)
        {
            return new RpcException(new Status(StatusCode.Unknown, exception.Message));
        }

    }
}
