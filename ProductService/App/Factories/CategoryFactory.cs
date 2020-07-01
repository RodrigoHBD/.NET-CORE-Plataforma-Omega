using ProductService.App.Models;
using ProductService.App.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.Factories
{
    public class CategoryFactory
    {
        public static Category MakeCategory(ICreateNewCategoryRequest request)
        {
            return new Category()
            {
                Name = request.Name
            };
        }
    }
}
