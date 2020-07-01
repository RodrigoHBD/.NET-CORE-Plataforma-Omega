using ProductService.App.Models;
using ProductService.App.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.Builders
{
    public class PhysicalProductBuilder
    {
        public static PhysicalProduct Build(ICreateNewPhysicalProductRequest request)
        {
            try
            {
                var product = ProductBuilder.Build(request);
                return new PhysicalProduct()
                {
                    Name = product.Name,
                    Description = product.Description,
                    Category = product.Category,
                    Brand = product.Brand,
                    Model = product.Model,
                    Color = product.Color,
                    Warranty = product.Warranty,
                    PicturesUrls = product.PicturesUrls,
                    Condition = product.Condition,
                    Measurements = request.Mesuarments,
                    Weight = request.Weight
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
