using ProductService.App.Entities;
using ProductService.App.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.UseCases
{
    public class BrandUseCaseController
    {
        public static async Task RegisterNewBrand(IRegisterNewBrandRequest request)
        {
            try
            {
                var brand = CreateNewBrand.Execute(request);
                await BrandEntity.ValidateNew(brand);
                await RegisterBrand.Execute(brand);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //public static async Task 
    }
}
