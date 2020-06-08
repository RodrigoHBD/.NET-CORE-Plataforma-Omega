using ShippingService.App.Factories;
using ShippingService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Entities
{
    public class LocationEntity
    {
        public static Location ExportInstanceOfDefaultLocation()
        {
            try
            {
                return LocationFactory.MakeDefaultLocation();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static Location ExportLocationForBeingTransported()
        {
            try
            {
                return LocationFactory.MakeLocationForPackageInMovement();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
