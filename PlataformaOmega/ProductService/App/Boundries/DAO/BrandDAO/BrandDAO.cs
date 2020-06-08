using MongoDB.Driver;
using ProductService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.Boundries.DAO
{
    public class BrandDAO
    {
        public static async Task RegisterBrand(Brand brand)
        {
            try
            {
                await Collections.Brands.InsertOneAsync(brand);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task<Brand> GetBrand(string id)
        {
            try
            {
                var filter = Builders<Brand>.Filter.Where(brand => brand.Id.ToString() == id);
                var query = await Collections.Brands.FindAsync(filter);
                return query.First();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task<bool> CheckIdBrandExist(string id)
        {
            try
            {
                var filter = Builders<Brand>.Filter.Where(brand => brand.Id.ToString() == id);
                var count = await Collections.Brands.CountDocumentsAsync(filter);
                var exists = count > 0;
                return exists;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task DeleteBrand(string id)
        {
            try
            {
                var filter = Builders<Brand>.Filter.Where(brand => brand.Id.ToString() == id);
                await Collections.Brands.DeleteOneAsync(filter);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
