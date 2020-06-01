using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductService.App.Entities.ProductDataFields;
using ProductService.App.Models.Product;

namespace ProductService.App.Entities
{
    public class ProductEntity
    {
        public static async Task ValidateNewProduct(Product product)
        {
            try
            {
                await ValidateDataFields(product);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static async Task ValidateDataFields(Product product)
        {
            try
            {
                Name.Validate(product.Name);
                Sku.Valdiate(product.Sku);
                Description.Valdiate(product.Description);
                Weight.Valdiate(product.Weight);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
