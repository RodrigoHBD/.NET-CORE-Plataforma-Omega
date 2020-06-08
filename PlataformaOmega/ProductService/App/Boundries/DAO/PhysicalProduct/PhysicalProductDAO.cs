using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using ProductService.App;
using ProductService.App.Models;

namespace ProductService.App.Boundries.DAO
{
    public class PhysicalProductDAO
    {
        public static async Task RegisterPhysicalProduct(PhysicalProduct product)
        {
            try
            {
                //await Collections.PhysicalProducts.InsertOneAsync(product);
                await Collections.Products.InsertOneAsync(product);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
