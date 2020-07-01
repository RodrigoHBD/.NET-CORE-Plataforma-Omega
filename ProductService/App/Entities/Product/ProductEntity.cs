using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductService.App.Boundries.DAO;
using ProductService.App.CustomExceptions;
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

        public static async Task ValidateProductId(string id)
        {
            try
            {
                var idExist = await ProductDAO.CheckIdExistsBool(id);

                if (!idExist)
                {
                    throw new ValidationException("Id", "Esse id de produto não existe");
                }
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
                Description.Valdiate(product.Description);
                await ProductDataFields.Category.Validate(product.Category);
                await ProductDataFields.Brand.Validate(product.Brand);
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
