using MongoDB.Driver;
using ProductService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.Boundries.DAO.CategoryDAO
{
    public class CategoryDAO
    {
        public static async Task<bool> CheckIfCategoryNameExists(string name)
        {
            try
            {
                var filter = Builders<Category>.Filter.Where(category => category.Name == name);
                var count = await Collections.Categories.CountDocumentsAsync(filter);
                var exists = count > 0;
                return exists;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
