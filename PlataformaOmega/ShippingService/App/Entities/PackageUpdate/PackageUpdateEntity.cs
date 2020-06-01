using ShippingService.App.Models;
using ShippingService.App.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Entities
{
    public class PackageUpdateEntity
    {
        public static async Task Validate(IPackageUpdateRequest update)
        {
            try
            {
                await ValidateDataFields(update);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static async Task ValidateDataFields(IPackageUpdateRequest update)
        {
            try
            {

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
