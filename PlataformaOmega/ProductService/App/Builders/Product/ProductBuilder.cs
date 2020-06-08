using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductService.App.Models;
using ProductService.App.Models.Input;

namespace ProductService.App.Builders
{
    public class ProductBuilder
    {
        public static Product Build(ICreateNewProductRequest request)
        {
            try
            {
                return new Product()
                {
                    Name = request.Name,
                    Description = request.Description,
                    Category = request.Category,
                    Brand = request.Brand,
                    Model = request.Model,
                    Color = request.Color,
                    Warranty = request.Warranty,
                    PicturesUrls = request.PicturesUrls,
                    Condition = request.Condition
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
