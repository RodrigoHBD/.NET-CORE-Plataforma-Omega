using ShippingService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Entities
{
    public class PackageMessagesEntity
    {
        public static PackageMessagesChangesReport CreateChangesReport(PackageStatusMessages messages, PackageStatusMessages messages2)
        {
            try
            {
                var report = new PackageMessagesChangesReport();
                
                if(messages.StatusDescription != messages2.StatusDescription)
                {
                    report.StatusDescriptionMustUpdate = true;
                }
                if(messages.RejectionReason != messages2.RejectionReason)
                {
                    report.RejectionReasonMustUpdate = true;
                }

                return report;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
