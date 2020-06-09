using ShippingService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.UseCases
{
    public class CheckIfPackageLocationChanged
    {
        public static PackageLocationChangesReport Execute(PackageLocation previousLocation, PackageLocation currentLocation)
        {
            try
            {
                
                var commingFromLocationChanged = CompareLocationsBool(previousLocation.CommingFrom, currentLocation.CommingFrom);
                var headedToLocationChanged = CompareLocationsBool(previousLocation.HeadedTo, currentLocation.HeadedTo);
                var currentLocationChanged = CompareLocationsBool(previousLocation.CurrentLocation, currentLocation.CurrentLocation);
                var anythingChanged = commingFromLocationChanged || headedToLocationChanged || currentLocationChanged;

                return new PackageLocationChangesReport()
                {
                    AnythingChanged = anythingChanged,
                    CommingFromLocationMustUpdate = commingFromLocationChanged,
                    HeadedToLocationMustUpdate = headedToLocationChanged,
                    CurrentLocationMustUpdate = currentLocationChanged
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static bool CompareLocationsBool(Location location1, Location location2)
        {
            try
            {
                var stateChanged = location1.State != location2.State;
                var cityChanged = location1.City != location2.City;
                var neighborhoodChanged = location1.Neighborhood != location2.Neighborhood;
                var streetNameChanged = location1.StreetName != location2.StreetName;
                var streetNumberChanged = location1.StreetNumber != location2.StreetNumber;
                var cepChanged = location1.Cep != location2.Cep;
                var anythingChanged = stateChanged || cityChanged || neighborhoodChanged || streetNameChanged
                    || streetNumberChanged || cepChanged;
                return anythingChanged;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
