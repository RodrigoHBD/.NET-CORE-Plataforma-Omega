using ShippingService.App.Boundries;
using ShippingService.App.Models;
using ShippingService.App.Models.MailerService.PackageData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.UseCases
{
    public class GetPackageDataWithMailerService
    {
        public static async Task<MailerServicePackageData> Execute(string trackingCode)
        {
            try
            {
                return await Mailer.GetPackageData(trackingCode);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
