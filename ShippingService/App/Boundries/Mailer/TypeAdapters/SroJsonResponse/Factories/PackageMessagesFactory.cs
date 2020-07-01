using ShippingService.App.Models;
using ShippingService.Correios.Models.Sro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Boundries.MailerTypeAdapters.SroJsonResponseFactories
{
    public class PackageMessagesFactory
    {
        public static PackageStatusMessages MakeFromLatestMessages(SroJsonResponse response)
        {
            try
            {
                return new PackageStatusMessages();
            }
            catch(Exception e)
            {
                throw;
            }
        }
    }
}
