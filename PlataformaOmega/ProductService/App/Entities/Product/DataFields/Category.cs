using ProductService.App.CustomExceptions;
using ProductService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.Entities.ProductDataFields
{
    public class Category
    {
        public static async Task Validate(string category)
        {
            try
            {
                await CategoryEntity.Validate(category);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
