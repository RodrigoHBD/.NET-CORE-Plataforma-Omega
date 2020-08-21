using ShippingService.App.Models;
using ShippingService.App.Models.Input;
using System;

namespace ShippingService.App.Factories
{
    public class PackageFactory
    {
        public static Package CreatePackage(NewPackageRequest request)
        {
            return new PackageFactory(request).GetPackage();
        }

        public Package GetPackage()
        {
            try
            {
                return new Package()
                {
                    Name = Request.Name,
                    WeightInGrams = Request.WeightInGrams,
                    Content = new PackageContent()
                    {
                        ProductIds = Request.ContentIds
                    }
                };
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public PackageFactory(NewPackageRequest request)
        {
            Request = request;
        }

        private NewPackageRequest Request { get; }

    }
}
