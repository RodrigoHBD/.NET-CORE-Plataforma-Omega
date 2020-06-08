using ProductService.App.Builders;
using ProductService.App.Models;
using ProductService.App.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.UseCases
{
    public class CreateNewPhysicalProduct
    {
        public static PhysicalProduct Execute(ICreateNewPhysicalProductRequest request)
        {
            try
            {
                return PhysicalProductBuilder.Build(request);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
