using ShippingService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Factories
{
    public class PackageWatcherFactory
    {
        public static PackageWatcher MakePackageWatcher(Package package)
        {
            try
            {
                return new PackageWatcher()
                {
                    PackageId = package.Id.ToString(),
                    TrackingCode = package.TrackingCode
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        } 
    }
}
