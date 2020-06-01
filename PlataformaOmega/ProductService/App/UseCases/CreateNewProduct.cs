using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductService.App.Factories;
using ProductService.App.Models.Product;

namespace ProductService.App.UseCases
{
    public class CreateNewProduct
    {
        public static async Task<Product> Execute()
        {
            try
            {
                return ProductFactory.MakeProduct();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
