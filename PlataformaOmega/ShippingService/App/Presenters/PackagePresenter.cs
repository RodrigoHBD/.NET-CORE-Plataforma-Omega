using ShippingService.App.Models;
using ShippingService.gRPC.Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Presenters
{
    public class PackagePresenter
    {
        public static GrpcPackageData PresentePackage(Package package)
        {
            return new GrpcPackageData()
            {
                Id = package.Id.ToString(),
                Name = package.Name,
                ProductId = package.ProductId,
                TrackingCode = package.TrackingCode,
                Status = new GrpcPackageStatus()
                {
                    IsAwaitingForPickUp = package.Status.IsAwaitingForPickUp,
                    IsBeingTransported = package.Status.IsBeingTransported,
                    IsDelivered = package.Status.HasBeenDelivered,
                    IsPosted = package.Status.HasBeenPosted,
                    IsRejected = package.Status.IsRejected,
                    Message = package.Status.Message
                },
                Locations = new GrpcPackageLocations()
                {
                    CurrentLocation = LocationPresenter.PresentLocation(package.Location.CurrentLocation),
                    HeadedToLocation = LocationPresenter.PresentLocation(package.Location.HeadedTo)
                }
            };
        }
    }
}
