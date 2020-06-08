using ProductService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.Boundries.DAO
{
    public class ProductDAO
    {
        public static async Task RegisterProduct(Product product)
        {
            try
            {
                await Collections.Products.InsertOneAsync(product);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
