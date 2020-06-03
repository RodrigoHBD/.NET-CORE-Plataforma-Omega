using ShippingService.App.Boundries;
using ShippingService.App.Models.Input;
using ShippingService.App.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.UseCases
{
    public class SearchPackageWatchers
    {
        public static async Task<IPackageWatcherList> Execute(IPackageWatcherSearch searchObj)
        {
            try
            {
                return await PackageWatcherDAO.SearchPackageWatchers(searchObj);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
