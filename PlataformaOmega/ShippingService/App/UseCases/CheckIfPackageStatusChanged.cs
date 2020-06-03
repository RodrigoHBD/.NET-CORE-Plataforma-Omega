using ShippingService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.UseCases
{
    public class CheckIfPackageStatusChanged
    {
        public static PackageStatusChangedReport Execute(PackageStatus previousStatus, PackageStatus currentStatus)
        {
            try
            {
                var messageChanged = CheckStatusMessage(previousStatus, currentStatus);
                var postedChanged = CheckPostedStatus(previousStatus, currentStatus);
                var deliveredChanged = CheckDeliveredStatus(previousStatus, currentStatus);

                var anythingChanged = messageChanged || postedChanged || deliveredChanged;

                return new PackageStatusChangedReport()
                {
                    AnythingChanged = anythingChanged,
                    MessageMustUpdate = messageChanged,
                    PostedMustUpdate = postedChanged ,
                    DeliveredMustUpdate = deliveredChanged
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
