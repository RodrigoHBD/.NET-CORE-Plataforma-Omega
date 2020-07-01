using ShippingService.App.Factories;
using ShippingService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.UseCases
{
    public class CreateNewPackageWatcher
    {
        public static PackageWatcher Execute(Package package)
        {
            try
            {
                return PackageWatcherFactory.MakePackageWatcher(package);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
