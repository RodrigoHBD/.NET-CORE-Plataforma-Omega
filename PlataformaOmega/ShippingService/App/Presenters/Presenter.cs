using ShippingService.App.Models;
using ShippingService.gRPC.Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Presenters
{
    public class Presenter
    {
        public static GrpcStatusResponse PresentStatusResponse(bool status, string message = "")
        {
            return new GrpcStatusResponse()
            {
                Ok = status,
                Message = message
            };
        }

        public static GrpcPackageData PresentPackage(Package package)
        {
            return new GrpcPackageData()
            {
                Id = package.Id.ToString(),
                Name = package.Name,
                TrackingCode = package.TrackingCode,
                ProductId = package.ProductId,
                Status = new GrpcPackageStatus()
                {
                    IsAwaitingForPickUp = package.Status.IsAwaitingForPickUp,
                    IsBeingTransported = package.Status.IsBeingTransported,
                    IsPosted = package.Status.HasBeenPosted,
                    IsDelivered = package.Status.HasBeenDelivered,
                    IsRejected = package.Status.IsRejected,
                    Message = package.Status.Message
                },
                Locations = new GrpcPackageLocations()
                {
                    CurrentLocation = PresentLocation(package.Location.CurrentLocation),
                    HeadedToLocation = PresentLocation(package.Location.HeadedTo)
                }
            };
        }

        private static GrpcLocation PresentLocation(Location location)
        {
            return new GrpcLocation()
            {
                State = location.State,
                Cep = location.Cep,
                City = location.City,
                StreetName = location.StreetName
            };
        }
    }
}
