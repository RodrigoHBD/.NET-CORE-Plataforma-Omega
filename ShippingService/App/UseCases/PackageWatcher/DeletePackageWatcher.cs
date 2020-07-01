using ShippingService.App.Boundries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.UseCases
{
    public class DeletePackageWatcher
    {
        public static async Task Execute(string packageId)
        {
            try
            {
                await PackageWatcherDAO.DeletePackageWatcherByPackageId(packageId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
