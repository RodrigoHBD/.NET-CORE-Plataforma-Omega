using ProductService.App.Boundries.DAO.CategoryDAO;
using ProductService.App.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.Entities.CategoryDataFields
{
    public class Name
    {
        public static async Task Validate(string name)
        {
            try
            {
                var exists = await CategoryDAO.CheckIfCategoryNameExists(name);

                if (!exists)
                {
                    throw new ValidationException("Nome da categoria", "Esse nome de categoria não existe");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
