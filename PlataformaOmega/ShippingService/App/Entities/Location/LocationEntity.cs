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

        public static bool CompareLocationsBool(Location location1, Location location2)
        {
            try
            {
                var stateMismatch = location1.State != location2.State;
                var cityMismatch = location1.City != location2.City;
                var cepMismatch = location1.Cep != location2.Cep;
                var neighborhoodMismatch = location1.Neighborhood != location2.Neighborhood;
                var streetNameMismatch = location1.StreetName != location2.StreetName;
                var streetNumberMismatch = location1.StreetNumber != location2.StreetNumber;

                var anyMismatched = stateMismatch || cityMismatch || cepMismatch || neighborhoodMismatch
                    || streetNameMismatch || streetNumberMismatch;

                return !anyMismatched;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
