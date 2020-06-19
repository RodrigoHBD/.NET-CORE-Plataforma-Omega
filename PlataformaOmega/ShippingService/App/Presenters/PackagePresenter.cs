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
            try
            {
                var grpcPackage = new GrpcPackageData()
                {
                    Id = package.Id.ToString(),
                    Name = package.Name,
                    TrackingCode = package.TrackingCode,
                    SaleId = package.SaleId,
                    IsBeingWatched = package.IsBeingWatched,
                    Weight = package.Weight,
                    BoundPlatform = AdaptPlatform(package),
                    CreatedManually = package.CreatedManually,
                    Status = new GrpcPackageStatus()
                    {
                        IsAwaitingForPickUp = package.Status.IsAwaitingForPickUp,
                        IsBeingTransported = package.Status.IsBeingTransported,
                        IsDelivered = package.Status.HasBeenDelivered,
                        IsPosted = package.Status.HasBeenPosted,
                        IsRejected = package.Status.IsRejected,
                        Message = package.Messages.StatusDescription
                    },
                    Locations = new GrpcPackageLocations()
                    {
                        CurrentLocation = LocationPresenter.PresentLocation(package.Location.CurrentLocation),
                        HeadedToLocation = LocationPresenter.PresentLocation(package.Location.HeadedTo)
                    }
                };
                package.Content.Products.ForEach(product => { grpcPackage.Content.Add(product); });
                return grpcPackage;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static string AdaptPlatform(Package package)
        {
            try
            {
                if (package.BoundPlatform == AvailablePlatformsToBind.MercadoLivre)
                {
                    return "mercado livre";
                }
                else
                {
                    return "nenhuma";
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
