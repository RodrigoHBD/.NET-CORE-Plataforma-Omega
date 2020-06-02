using ShippingService.App.Boundries;
using ShippingService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.UseCases
{
    public class UpdatePackage
    {
        public static async Task Execute(string id, PackageUpdate update)
        {
            try
            {
                await DAO.UpdatePackage(id, update);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
