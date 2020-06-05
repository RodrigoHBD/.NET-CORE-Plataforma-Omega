using MongoDB.Bson;
using MongoDB.Driver;
using ShippingService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;

namespace ShippingService.App.Boundries
{
    public class DAO
    {
        public static async Task RegisterPackage(Package package)
        {
            try
            {
                await Collections.Packages.InsertOneAsync(package);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //TODO separar em metodos individuais privados
        public static async Task UpdatePackage(string id, PackageUpdate packageUpdate)
        {
            try
            {
                var filter = Builders<Package>.Filter.Where(package => package.Id == ObjectId.Parse(id));
                var somthingWasChanged = false;
                
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
                       .Set(package => package.Status.Message, packageUpdate.StatusMessage)
                       .Set(package => package.Dates.DeliveredAt, DateTime.UtcNow);

                    await Collections.Packages.UpdateOneAsync(filter, update);
                    somthingWasChanged = true;
                }
                if (packageUpdate.SetAwaitingForPickUp)
                {
                    var update = Builders<Package>.Update
                       .Set(package => package.Status.IsAwaitingForPickUp, true)
                       .Set(package => package.Dates.DeliveredAt, DateTime.UtcNow);

                    await Collections.Packages.UpdateOneAsync(filter, update);
                    somthingWasChanged = true;
                }
                if (packageUpdate.SetIsRejected)
                {
                    var update = Builders<Package>.Update
                       .Set(package => package.Status.IsRejected, true)
                       .Set(package => package.Dates.DeliveredAt, DateTime.UtcNow);

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
            catch (Exception e)
            {
                throw e;
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
                throw e;
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
                throw e;
            }
        }

    }
}
