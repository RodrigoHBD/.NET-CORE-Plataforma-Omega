using ProductService.App.Entities.PhysicalProductDataFields;
using ProductService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.Entities
{
    public class PhysicalProductEntity
    {
        public static async Task ValidateNewPhysicalProduct(PhysicalProduct product)
        {
            try
            {
                await ProductEntity.ValidateNewProduct(product);
                await ValidateDataFields(product);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static async Task ValidateDataFields(PhysicalProduct product)
        {
            try
            {
                Weight.Valdiate(product.Weight);
                Measurements.Validate(product.Measurements);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
