using ShippingService.App.Boundries;
using ShippingService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.UseCases
{
    public class RegisterPackageWatcher
    {
        public static async Task Execute(PackageWatcher packageWatcher)
        {
            try
            {
                await PackageWatcherDAO.RegisterPackageWatcher(packageWatcher);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
