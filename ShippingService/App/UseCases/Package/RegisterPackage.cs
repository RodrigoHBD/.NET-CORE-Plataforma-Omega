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
        public async Task<string> Execute(Package package)
        {
            try
            {
                return await PackageDAO.RegisterPackage(package);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
