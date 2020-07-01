using ProductService.App.Entities;
using ProductService.App.Models.Input;
using ProductService.App.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.UseCases
{
    public class PhysicalProductUseCaseController
    {
        public static async Task<IPhysicalProductSearchOutput> SearchPhysicalProductsAsync(IProductSearch search)
        {
            try
            {
                await ProductSearchEntity.ValidateSearch(search);
                return await SearchPhysicalProducts.Execute(search);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
