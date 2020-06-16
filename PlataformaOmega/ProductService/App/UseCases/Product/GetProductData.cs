using ProductService.App.Boundries.DAO;
using ProductService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.UseCases
{
    public class GetProductData
    {
        public static async Task<Product> Execute(string id)
        {
            try
            {
                return await ProductDAO.GetProductData(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
