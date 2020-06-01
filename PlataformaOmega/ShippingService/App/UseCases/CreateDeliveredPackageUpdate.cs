using ShippingService.App.Factories;
using ShippingService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.UseCases
{
    public class CreateDeliveredPackageUpdate
    {
        public static PackageUpdate Execute()
        {
            try
            {
                return PackageFactory.MakePackageDeliveredUpdate();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
