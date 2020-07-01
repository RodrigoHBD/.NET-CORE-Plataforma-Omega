using MongoDB.Driver;
using ProductService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.Boundries.DAO
{
    public class ProductDAO
    {
        public static async Task RegisterProduct(Product product)
        {
            try
            {
                await Collections.Products.InsertOneAsync(product);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task<Product> GetProductData(string id)
        {
            try
            {
                var filter = Builders<Product>.Filter.Where(product => product.Id.ToString() == id);
                var query = await Collections.Products.FindAsync(filter);
                return query.FirstOrDefault();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task<bool> CheckIdExistsBool(string id)
        {
            try
            {
                var filter = Builders<Product>.Filter.Where(product => product.Id.ToString() == id);
                var count = await Collections.Products.CountDocumentsAsync(filter);
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
