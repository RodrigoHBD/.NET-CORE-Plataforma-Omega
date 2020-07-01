using ProductService.App.Entities;
using ProductService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.UseCases
{
    public class ProductUseCaseController
    {
        public static async Task<Product> GetProductDataAsync(string id)
        {
            try
            {
                await ProductEntity.ValidateProductId(id);
                return await GetProductData.Execute(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
