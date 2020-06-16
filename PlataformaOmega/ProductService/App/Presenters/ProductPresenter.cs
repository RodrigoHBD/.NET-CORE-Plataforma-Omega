using ProductService.App.Models;
using ProductService.gRPC.Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.Presenters
{
    public class ProductPresenter
    {
        public static GrpcProduct PresentProduct(Models.Product product)
        {
            return new GrpcProduct();
        }

        public static GrpcProduct PresentPhysicalProduct(PhysicalProduct product)
        {
            return new GrpcProduct()
            {

            };
        }
    }
}
