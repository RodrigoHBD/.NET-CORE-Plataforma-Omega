using MongoDB.Bson;
using MongoDB.Driver;
using ShippingService.App.Boundries.DAO.ReturnModels;
using ShippingService.App.Boundries.DAOReturnModels;
using ShippingService.App.Models;
using ShippingService.App.Models.Input;
using ShippingService.App.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
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
                var somthingWasChanged = false;

                if (packageUpdate.IsBeingWatched.IsActive)
                {
                    var update = Builders<Package>.Update
                        .Set(package => package.IsBeingWatched, packageUpdate.IsBeingWatched.Toggler);
                    await Collections.Packages.UpdateOneAsync(filter, update);
                }
               
                if (packageUpdate.SetPosted)
                {
                    var update = Builders<Package>.Update
                        .Set(package => package.Status.HasBeenPosted, true)
                        .Set(package => package.Dates.PostedAt, DateTime.UtcNow);

                    await Collections.Packages.UpdateOneAsync(filter, update);
                    somthingWasChanged = true;
                }

                if (packageUpdate.SetDelivered)
                {
                    var update = Builders<Package>.Update
                        .Set(package => package.Status.HasBeenDelivered, true)
                        .Set(package => package.Dates.DeliveredAt, DateTime.UtcNow);

                    await Collections.Packages.UpdateOneAsync(filter, update);
                    somthingWasChanged = true;
                }
                if(packageUpdate.StatusMessage.Length > 0)
                {
                    var update = Builders<Package>.Update
                       .Set(package => package.Messages.StatusDescription, packageUpdate.StatusMessage);

                    await Collections.Packages.UpdateOneAsync(filter, update);
                    somthingWasChanged = true;
                }
                if (packageUpdate.AwaitingForPickUp.IsActive)
                {
                    var update = Builders<Package>.Update
                       .Set(package => package.Status.IsAwaitingForPickUp, packageUpdate.AwaitingForPickUp.Toggler);

                    await Collections.Packages.UpdateOneAsync(filter, update);
                    somthingWasChanged = true;
                }
                if (packageUpdate.SetIsRejected)
                {
                    var update = Builders<Package>.Update
                       .Set(package => package.Status.IsRejected, true);

                    await Collections.Packages.UpdateOneAsync(filter, update);
                    somthingWasChanged = true;
                }
                if (packageUpdate.IsBeingTransported.IsActive)
                {
                    var update = Builders<Package>.Update
                       .Set(package => package.Status.IsBeingTransported, packageUpdate.IsBeingTransported.Toggler);

                    await Collections.Packages.UpdateOneAsync(filter, update);
                    somthingWasChanged = true;
                }
                //locations
                if (packageUpdate.CommingFrom.MustUpdate)
                {
                    var update = Builders<Package>.Update
                       .Set(package => package.Location.CommingFrom, packageUpdate.CommingFrom.Location);

                    await Collections.Packages.UpdateOneAsync(filter, update);
                    somthingWasChanged = true;
                }
                if (packageUpdate.HeadedTo.MustUpdate)
                {
                    var update = Builders<Package>.Update
                       .Set(package => package.Location.HeadedTo, packageUpdate.HeadedTo.Location);

                    await Collections.Packages.UpdateOneAsync(filter, update);
                    somthingWasChanged = true;
                }
                if (packageUpdate.CurrentLocation.MustUpdate)
                {
                    var update = Builders<Package>.Update
                       .Set(package => package.Location.CurrentLocation, packageUpdate.CurrentLocation.Location);

                    await Collections.Packages.UpdateOneAsync(filter, update);
                    somthingWasChanged = true;
                }


                if (somthingWasChanged)
                {
                    var update = Builders<Package>.Update
                        .Set(package => package.Dates.LastUpdated, DateTime.UtcNow);

                    await Collections.Packages.UpdateOneAsync(filter, update);
                }
                
            }
            catch (Exception)
            {
                throw ;
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

        public static async Task<Location> GetPackageCurrentLocation(string id)
        {
            try
            {
                var filter = Builders<Package>.Filter.Where(package => package.Id == ObjectId.Parse(id));
                var query = Collections.Packages.Find(filter).Project(package => package.Location.CurrentLocation);
                var location = query.First();
                return location;
            }
            catch (Exception e)
            {
                throw ;
            }
        }

        public static async Task<PackageStatus> GetPackageStatus(string id)
        {
            try
            {
                var filter = Builders<Package>.Filter.Where(package => package.Id == ObjectId.Parse(id));
                var query = Collections.Packages.Find(filter).Project(package => package.Status);
                var status = query.First();
                return status;
            }
            catch (Exception e)
            {
                throw ;
            }
        }

        public static async Task<IPackageList> SearchPackages(IPackageSearchRequest request)
        {
            try
            {
                var nameFilter = Builders<Package>.Filter.Empty;
                var trackingCodeFilter = Builders<Package>.Filter.Empty;
                var dynamicFilter = Builders<Package>.Filter.Empty;
                var filter = Builders<Package>.Filter.Empty;

                if (request.DynamicString.IsActive)
                {
                    nameFilter = Builders<Package>.Filter.Where(package => package.Name.Contains(request.DynamicString.Value));
                    trackingCodeFilter = Builders<Package>.Filter.Where(package => package.TrackingCode == request.DynamicString.Value);
                    dynamicFilter = Builders<Package>.Filter.Or(nameFilter, trackingCodeFilter);
                }
                else
                {
                    //TODO
                }

                filter = Builders<Package>.Filter.And(dynamicFilter);

                var total = await CountPackagesAsync(filter);
                var query = Collections.Packages.Find(filter).Limit(request.Pagination.Limit).Skip(request.Pagination.Offset);

                return new PackageList()
                {
                    Packages = query.ToList(),
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
