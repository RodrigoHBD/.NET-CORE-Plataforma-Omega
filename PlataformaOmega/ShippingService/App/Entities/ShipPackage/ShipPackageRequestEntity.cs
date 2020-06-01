using ShippingService.App.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Entities.NewPackageRequest
{
    public class ShipPackageRequestEntity
    {
        public static async Task Valdiate(IShipPackageRequest request)
        {
            try
            {
                await ValidateDataFields(request);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static async Task ValidateDataFields(IShipPackageRequest request)
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
