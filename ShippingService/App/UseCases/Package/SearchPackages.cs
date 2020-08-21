using ShippingService.App.Boundries;
using ShippingService.App.Models.Input;
using ShippingService.App.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.UseCases
{
    public class SearchPackages
    {
        public static async Task<PackageList> Execute(SearchPackageRequest request)
        {
            try
            {
                return await PackageDAO.SearchPackages(request);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
