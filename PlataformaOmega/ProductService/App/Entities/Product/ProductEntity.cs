using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductService.App.Entities.ProductDataFields;
using ProductService.App.Models;

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
                // 3 caracter minimo
                Name.Validate(product.Name);
                Description.Valdiate(product.Description);
                Category.Validate(product.Category);
                // base
                ProductDataFields.Brand.Validate(product.Brand);
                // base
                Model.Validate(product.Model);
                Color.Validate(product.Color);
                Warranty.Validate(product.Warranty);
                Pictures.Validate(product.PicturesUrls);
                Condition.Validate(product.Condition);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
