using ShippingService.App.Entities.PackageSearchDataFields;
using ShippingService.App.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Entities.PackageSearch
{
    public class PackageSearchEntity
    {
        public static void ValidateRequest(IPackageSearchRequest request)
        {
            try
            {
                ValidateDataFields(request);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static void ValidateDataFields(IPackageSearchRequest request)
        {
            try
            {
                Pagination.Validate(request.Pagination);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
