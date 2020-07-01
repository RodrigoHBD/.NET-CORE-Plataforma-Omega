using ProductService.App.Entities;
using ProductService.App.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.UseCases
{
    public class UseCaseOperator
    {
        public static async Task CreateNewPhysicalProductAsync(ICreateNewPhysicalProductRequest request)
        {
            try
            {
                await NewPhysicalProductRequestEntity.ValidateRequest(request);

                var product = CreateNewPhysicalProduct.Execute(request);
                await PhysicalProductEntity.ValidateNewPhysicalProduct(product);
                await RegisterProduct.Execute(product);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
