using ProductService.App.Presenters;
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

        public static async Task<GrpcProduct> GetProductData(GrpcIdMessage grpcRequest)
        {
            try
            {
                var id = grpcRequest.Id;
                var product = await ProductUseCaseController.GetProductDataAsync(id);
                return ProductPresenter.PresentProduct(product);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
