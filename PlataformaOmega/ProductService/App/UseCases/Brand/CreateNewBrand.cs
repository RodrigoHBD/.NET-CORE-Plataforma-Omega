using ProductService.App.Models;
using ProductService.App.Factories;
using ProductService.App.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.UseCases
{
    public class CreateNewBrand
    {
        public static Brand Execute(IRegisterNewBrandRequest request)
        {
            try
            {
                return BrandFactory.MakeBrand(request);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
