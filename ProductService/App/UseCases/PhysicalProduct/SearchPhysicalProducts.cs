using ProductService.App.Boundries.DAO;
using ProductService.App.Models.Input;
using ProductService.App.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.UseCases
{
    public class SearchPhysicalProducts
    {
        public static async Task<IPhysicalProductSearchOutput> Execute(IProductSearch search)
        {
            try
            {
                return await PhysicalProductDAO.SearchPhysicalProducts(search);
            }
            catch (Exception e)
            {
                throw e;
            } 
        }
    }
}
