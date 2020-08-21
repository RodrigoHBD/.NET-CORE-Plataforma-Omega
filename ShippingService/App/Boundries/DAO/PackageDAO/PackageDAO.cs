using MongoDB.Bson;
using MongoDB.Driver;
using ShippingService.App.Models;
using ShippingService.App.Models.Input;
using ShippingService.App.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Boundries
{
    public class PackageDAO
    {
        public static async Task<string> RegisterPackage(Package package)
        {
            try
            {
                await Collections.Packages.InsertOneAsync(package);
                return package.Id.ToString();
            }
            catch (Exception e)
            {
                throw ;
            }
        }

        //TODO separar em metodos individuais privados
        public static async Task UpdatePackage(string id, PackageUpdate packageUpdate)
        {
            try
            {
                var filter = Builders<Package>.Filter.Where(package => package.Id == ObjectId.Parse(id));
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<bool> CheckIdPackageIdExist(string id)
        {
            try
            {
                var filter = Builders<Package>.Filter.Where(package => package.Id == ObjectId.Parse(id));
                var query = await Collections.Packages.FindAsync(filter);
                var exists = query.ToList().Count > 0;
                return exists;
            }
            catch (Exception e)
            {
                throw ;
            }
        }

        public static async Task<Package> GetPackage(string id)
        {
            try
            {
                var filter = Builders<Package>.Filter.Where(package => package.Id == ObjectId.Parse(id));
                var query = await Collections.Packages.FindAsync(filter);
                var package = query.First();
                return package;
            }
            catch (Exception e)
            {
                throw ;
            }
        }

        public static async Task<PackageList> SearchPackages(SearchPackageRequest request)
        {
            try
            {
                var filter = Builders<Package>.Filter.Empty;
                var total = await CountPackagesAsync(filter);
                var query = Collections.Packages.Find(filter).Limit(request.Pagination.Limit)
                    .Skip(request.Pagination.Offset)
                    .Sort(Builders<Package>.Sort.Descending(package => package.Dates.CreatedAt));

                return new PackageList()
                {
                    Data = query.ToList(),
                    Pagination = new PaginationOut()
                    {
                        Limit = request.Pagination.Limit,
                        Offset = request.Pagination.Offset,
                        Total = total
                    }
                };
            }
            catch (Exception e)
            {
                throw ;
            }
        }

        private static async Task<int> CountPackagesAsync(FilterDefinition<Package> filter)
        {
            try
            {
                return (int) await Collections.Packages.CountDocumentsAsync(filter);
            }
            catch (Exception e)
            {
                throw ;
            }
        }

        public static async Task HardDeletePackage(string id)
        {
            try
            {
                var filter = Builders<Package>.Filter.Where(package => package.Id == ObjectId.Parse(id));
                await Collections.Packages.DeleteOneAsync(filter);
            }
            catch (Exception e)
            {
                throw ;
            }
        }
    }
}
