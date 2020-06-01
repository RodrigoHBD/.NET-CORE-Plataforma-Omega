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

    }
}
