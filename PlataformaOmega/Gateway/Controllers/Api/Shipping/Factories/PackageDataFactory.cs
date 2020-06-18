using Gateway.Controllers.Api.Shipping.Models.Output;
using Gateway.gRPC.Client.ShippingClientProto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Gateway.Controllers.Api.Shipping.Factories
{
    public class PackageDataFactory
    {
        public static PackageData Make(GrpcPackageData data)
        {
            return new PackageData()
            {
                Id = data.Id,
                Name = data.Name,
                BoundPlatform = data.BoundPlatform,
                SaleId = data.SaleId,
                TrackingCode = data.TrackingCode,
                Weight = data.Weight,
                IsWatched = data.IsBeingWatched,
                Content = MakePackageDataContent(data),
                Locations = new PackageLocations()
                {
                    CurrentLocation = LocationFactory.Make(data.Locations.CurrentLocation),
                    HeadedToLocation = LocationFactory.Make(data.Locations.HeadedToLocation)
                },
                Messages = new PackageMessages()
                {
                    StatusDescription = data.Status.Message
                },
                Status = new PackageStatus()
                {
                    IsPosted = data.Status.IsPosted,
                    IsAwaitingForPickUp = data.Status.IsAwaitingForPickUp,
                    IsBeingTransported = data.Status.IsBeingTransported,
                    IsDelivered = data.Status.IsDelivered,
                    IsRejected = data.Status.IsRejected
                }
            };
        }

        private static List<string> MakePackageDataContent(GrpcPackageData data)
        {
            try
            {
                var list = new List<string>();
                data.Content.ToList().ForEach(product => 
                {
                    list.Add(product);
                });
                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static string MakeSerialized(GrpcPackageData data)
        {
            try
            {
                var packageData = Make(data);
                return JsonSerializer.Serialize(packageData);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
