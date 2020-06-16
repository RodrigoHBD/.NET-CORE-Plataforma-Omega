using ProductService.App.Boundries.DAO;
using ProductService.App.Entities.CategoryDataFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.Entities
{
    public class CategoryEntity
    {
        public static async Task Validate(string category)
        {
            try
            {
                await ValidateName(category);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static async Task ValidateName(string category)
        {
            try
            {
                await CategoryDataFields.Name.Validate(category);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
