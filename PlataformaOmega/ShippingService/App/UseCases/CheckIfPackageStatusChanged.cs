using Google.Protobuf.WellKnownTypes;
using ShippingService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.UseCases
{
    public class CheckIfPackageStatusChanged
    {
        public static PackageStatusChangesReport Execute(PackageStatus previousStatus, PackageStatus currentStatus)
        {
            try
            {
                var messageChanged = CheckStatusMessage(previousStatus, currentStatus);
                var postedChanged = CheckPostedStatus(previousStatus, currentStatus);
                var deliveredChanged = CheckDeliveredStatus(previousStatus, currentStatus);
                var awaitingForPickUpChanged = CheckAwaitingForPickUpStatus(previousStatus, currentStatus);
                var isRejectedChanged = CheckIsRejectedStatus(previousStatus, currentStatus);
                var IsBeingTransportedChanged = CheckIsBeingTransportedStatus(previousStatus, currentStatus);

                var anythingChanged = messageChanged || postedChanged || deliveredChanged || awaitingForPickUpChanged
                    || isRejectedChanged || IsBeingTransportedChanged;

                return new PackageStatusChangesReport()
                {
                    AnythingChanged = anythingChanged,
                    MessageMustUpdate = messageChanged,
                    PostedMustUpdate = postedChanged ,
                    DeliveredMustUpdate = deliveredChanged,
                    AwaitingForPickUpMustUpdate = awaitingForPickUpChanged,
                    IsRejectedMustUpdate = isRejectedChanged,
                    IsBeingTransportedMustUpdate = IsBeingTransportedChanged
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static bool CheckStatusMessage(PackageStatus previousStatus, PackageStatus currentStatus)
        {
            try
            {
                var hasChanged = previousStatus.Message != currentStatus.Message;
                return hasChanged;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static bool CheckAwaitingForPickUpStatus(PackageStatus previousStatus, PackageStatus currentStatus)
        {
            try
            {
                var hasChanged = previousStatus.IsAwaitingForPickUp != currentStatus.IsAwaitingForPickUp;
                return hasChanged;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static bool CheckIsBeingTransportedStatus(PackageStatus previousStatus, PackageStatus currentStatus)
        {
            try
            {
                var hasChanged = previousStatus.IsBeingTransported != currentStatus.IsBeingTransported;
                return hasChanged;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static bool CheckIsRejectedStatus(PackageStatus previousStatus, PackageStatus currentStatus)
        {
            try
            {
                var hasChanged = previousStatus.IsRejected != currentStatus.IsRejected;
                return hasChanged;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static bool CheckPostedStatus(PackageStatus previousStatus, PackageStatus currentStatus)
        {
            try
            {
                var postedChanged = previousStatus.HasBeenPosted != currentStatus.HasBeenPosted;
                return postedChanged;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static bool CheckDeliveredStatus(PackageStatus previousStatus, PackageStatus currentStatus)
        {
            try
            {
                var deliveredChanged = previousStatus.HasBeenDelivered != currentStatus.HasBeenDelivered;
                return deliveredChanged;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
