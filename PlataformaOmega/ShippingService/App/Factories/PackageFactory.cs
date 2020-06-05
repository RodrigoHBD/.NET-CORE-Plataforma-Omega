using ShippingService.App.Models;
using ShippingService.App.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Factories
{
    public class PackageFactory
    {
        public static Package MakePackage(IShipPackageRequest request)
        {
            try
            {
                return new Package()
                {
                    Name = request.Name,
                    TrackingCode = request.TrackingCode,
                    ProductId = request.ProductId
                };
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public static PackageUpdate MakePackagePostedUpdate()
        {
            try
            {
                return new PackageUpdate()
                {
                    SetDelivered = false,
                    SetPosted = true
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static PackageUpdate MakePackageDeliveredUpdate()
        {
            try
            {
                return new PackageUpdate()
                {
                    SetDelivered = true,
                    SetPosted = false
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static PackageUpdate MakePackageStatusMessageUpdate(string message)
        {
            try
            {
                return new PackageUpdate()
                {
                    StatusMessage = message
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static PackageUpdate MakePackageAwaitingForPickUpUpdate()
        {
            try
            {
                return new PackageUpdate()
                {
                    SetAwaitingForPickUp = true
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static PackageUpdate MakePackageIsRejectedUpdate()
        {
            try
            {
                return new PackageUpdate()
                {
                    SetIsRejected = true
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
