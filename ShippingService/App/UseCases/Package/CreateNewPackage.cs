using ShippingService.App.Factories;
using ShippingService.App.Models;
using ShippingService.App.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.UseCases
{
    public class CreateNewPackage
    {
        public static Package Execute(IShipPackageRequest request)
        {
            try
            {
                return PackageFactory.MakePackage(request);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
