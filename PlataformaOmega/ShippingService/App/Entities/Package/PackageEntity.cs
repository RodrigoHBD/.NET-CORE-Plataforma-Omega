using ShippingService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Entities
{
    public class PackageEntity
    {
        public static async Task ValidateNewPackage(Package package)
        {
            try
            {
                await ValidateDataFields(package);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task ValidatePackageId(string id)
        {
            try
            {

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static async Task ValidateDataFields(Package package)
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
