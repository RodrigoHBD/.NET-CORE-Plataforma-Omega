using ShippingService.App.Boundries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.UseCases
{
    public class GetPackageWatcher
    {
        public static async Task Execute(string id)
        {
            try
            {
                await PackageWatcherDAO.DeletePackageWatcher(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
