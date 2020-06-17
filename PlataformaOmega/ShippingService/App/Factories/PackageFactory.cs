using ShippingService.App.Models;
using ShippingService.App.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Factories
{
    public class PackageFactory
    {
        public static Package MakePackage(IShipPackageRequest request)
        {
            try
            {
                var package = new Package()
                {
                    Name = request.Name,
                    TrackingCode = request.TrackingCode,
                    SaleId = request.SaleId,
                    Weight = request.Weight,
                    BoundPlatform = request.Platform,
                    Content = new PackageContent()
                    {
                        Products = request.Content
                    }
                };
                package.Location.ShippedFrom = request.PackageInitialLocation;

                return package;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public static PackageUpdate MakePackagePostedUpdate()
        {
            try
            {
                return new PackageUpdate()
                {
                    SetPosted = true
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static PackageUpdate MakePackageDeliveredUpdate()
        {
            try
            {
                return new PackageUpdate()
                {
                    SetDelivered = true,
                    SetPosted = false
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static PackageUpdate MakePackageStatusMessageUpdate(string message)
        {
            try
            {
                return new PackageUpdate()
                {
                    StatusMessage = message
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static PackageUpdate MakePackageAwaitingForPickUpUpdate(bool toggle = false)
        {
            try
            {
                return new PackageUpdate()
                {
                    AwaitingForPickUp = new BoolToggler()
                    {
                        IsActive = true,
                        Toggler = toggle
                    }
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static PackageUpdate MakePackageIsBeingTransportedUpdate(bool toggle)
        {
            try
            {
                return new PackageUpdate()
                {
                    IsBeingTransported = new BoolToggler()
                    {
                        IsActive = true,
                        Toggler = toggle
                    }
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static PackageUpdate MakePackageIsRejectedUpdate()
        {
            try
            {
                return new PackageUpdate()
                {
                    SetIsRejected = true
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static PackageUpdate MakePackageCommingFromLocationUpdate(Location location)
        {
            try
            {
                var update = new PackageUpdate();
                update.CommingFrom.MustUpdate = true;
                update.CommingFrom.Location = location;
                update.CurrentLocation.Location.IsSet = true;
                return update;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static PackageUpdate MakePackageCurrentLocationUpdate(Location location)
        {
            try
            {
                var update = new PackageUpdate();
                update.CurrentLocation.MustUpdate = true;
                update.CurrentLocation.Location = location;
                update.CurrentLocation.Location.IsSet = true;
                return update;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static PackageUpdate MakePackageHeadedToLocationUpdate(Location location)
        {
            try
            {
                var update = new PackageUpdate();
                update.HeadedTo.MustUpdate = true;
                update.HeadedTo.Location = location;
                update.HeadedTo.Location.IsSet = true;
                return update;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static PackageUpdate MakePackageIsBeingWatchedUpdate(bool toggle = false)
        {
            try
            {
                return new PackageUpdate()
                {
                    AwaitingForPickUp = new BoolToggler()
                    {
                        IsActive = true,
                        Toggler = toggle
                    }
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
