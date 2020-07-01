using ProductService.App.Boundries.DAO;
using ProductService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.UseCases
{
    public class RegisterProduct
    {
        public static async Task Execute(Product product)
        {
            try
            {
                await ProductDAO.RegisterProduct(product);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
