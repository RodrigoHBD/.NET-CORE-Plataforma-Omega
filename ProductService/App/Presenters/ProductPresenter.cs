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
        public static GrpcProduct PresentProduct<T>(T product)
        {
            try
            {
                if(product is PhysicalProduct)
                {
                    return PresentPhysicalProduct(product as PhysicalProduct);
                }
                else
                {
                    return PresentPhysicalProduct(product as PhysicalProduct);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static GrpcProduct PresentPhysicalProduct(PhysicalProduct product)
        {
            return new GrpcProduct()
            {
                Id = product.Id.ToString(),
                Name = product.Name,
                Brand = product.Brand,
                Category = product.Category,
                Description = product.Description,
                Measurements = MeasurementsPresenter.PresentPhysicalMeasurements(product.Measurements)
            };
        }
    }
}
