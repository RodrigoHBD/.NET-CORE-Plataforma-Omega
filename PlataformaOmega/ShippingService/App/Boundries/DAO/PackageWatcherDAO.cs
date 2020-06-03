using Microsoft.VisualBasic;
using MongoDB.Bson;
using MongoDB.Driver;
using ShippingService.App.Boundries.DAOReturnModels;
using ShippingService.App.Models;
using ShippingService.App.Models.Input;
using ShippingService.App.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Boundries
{
    public class PackageWatcherDAO
    {
        public static async Task<PackageWatcher> GetPackageWatcherById(string id)
        {
            try
            {
                var filter = Builders<PackageWatcher>.Filter.Where(package => package.Id == ObjectId.Parse(id));
                var query = await Collections.PackageWatcher.FindAsync(filter);
                var package = query.First();
                return package;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task RegisterPackageWatcher(PackageWatcher packageWatcher)
        {
            try
            {
                await Collections.PackageWatcher.InsertOneAsync(packageWatcher);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task DeletePackageWatcher(string id)
        {
            try
            {
                var filter = Builders<PackageWatcher>.Filter.Where(package => package.Id == ObjectId.Parse(id));
                await Collections.PackageWatcher.DeleteOneAsync(filter);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task<bool> CheckIfExistById(string id)
        {
            try
            {
                var filter = Builders<PackageWatcher>.Filter.Where(package => package.Id == ObjectId.Parse(id));
                var count = await Collections.PackageWatcher.CountDocumentsAsync(filter);
                var exists = count > 0;
                return exists;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task<IPackageWatcherList> SearchPackageWatchers(IPackageWatcherSearch search)
        {
            try
            {
                var trackingCodeFilter = Builders<PackageWatcher>.Filter.Empty;
                var packageIdFilter = Builders<PackageWatcher>.Filter.Empty;

                if(search.PackageId.Length > 0)
                {

                }
                if(search.TrackingCode.Length > 0)
                {

                }

                var filter = Builders<PackageWatcher>.Filter.And(trackingCodeFilter, packageIdFilter);
                var query = Collections.PackageWatcher.Find(filter).Skip(search.Pagination.Offset).Limit(search.Pagination.Limit);
                var total = await CountWithFilter(filter);

                return new PackageWatcherList()
                {
                    Watchers = query.ToList(),
                    Pagination = new PaginationOut()
                    {
                        Offset = search.Pagination.Offset,
                        Limit = search.Pagination.Limit,
                        Total = total
                    }
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static async Task<int> CountWithFilter(FilterDefinition<PackageWatcher> filter)
        {
            try
            {
                return (int) await Collections.PackageWatcher.CountDocumentsAsync(filter);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
