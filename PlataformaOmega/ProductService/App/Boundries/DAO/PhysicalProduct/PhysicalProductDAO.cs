using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using MongoDB.Bson;
using MongoDB.Driver;
using ProductService.App;
using ProductService.App.Models;
using ProductService.App.Models.Input;
using ProductService.App.Models.Output;

namespace ProductService.App.Boundries.DAO
{
    public class PhysicalProductDAO
    {
        public static async Task<IPhysicalProductSearchOutput> SearchPhysicalProducts(IProductSearch search)
        {
            try
            {
                var idFilter = Builders<PhysicalProduct>.Filter.Empty;
                var nameFilter = Builders<PhysicalProduct>.Filter.Empty;
                var categoryFilter = Builders<PhysicalProduct>.Filter.Empty;
                var brandFilter = Builders<PhysicalProduct>.Filter.Empty;
                var ownerFilter = Builders<PhysicalProduct>.Filter.Empty;
                var filter = Builders<PhysicalProduct>.Filter.Empty;

                if (search.Id.IsActive)
                {
                    idFilter = Builders<PhysicalProduct>.Filter.Where(product => product.Id == ObjectId.Parse(search.Id.Value) );
                }
                if (search.Name.IsActive)
                {
                    nameFilter = Builders<PhysicalProduct>.Filter.Where(product => product.Name == search.Name.Value);
                }
                if (search.Owner.IsActive)
                {
                    ownerFilter = Builders<PhysicalProduct>.Filter.Where(product => product.Owner == search.Owner.Value);
                }

                filter = Builders<PhysicalProduct>.Filter.And(idFilter, nameFilter, ownerFilter);
                var query = Collections.PhysicalProducts.Find(filter).Skip(search.Pagination.Offset).Limit(search.Pagination.Limit);

                return new PhysicalProductSearchOutput()
                {
                    Products = query.ToList(),
                    Pagination = new PaginationOut()
                    {
                        Offset = search.Pagination.Offset,
                        Limit =  search.Pagination.Limit,
                        Total = await Count(filter)
                    }
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static async Task<int> Count(FilterDefinition<PhysicalProduct> filter)
        {
            try
            {
                return (int) await Collections.PhysicalProducts.CountDocumentsAsync(filter);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
