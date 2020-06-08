using ShippingService.App.Boundries;
using ShippingService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.UseCases
{
    public class RegisterPackage
    {
        public static async Task Execute(Package package)
        {
            try
            {
                await PackageDAO.RegisterPackage(package);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
