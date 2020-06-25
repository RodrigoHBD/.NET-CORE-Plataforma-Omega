using ShippingService.App.Boundries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.UseCases
{
    public class DeletePackage
    {
        public static async Task Execute(string id)
        {
            try
            {
                await PackageDAO.HardDeletePackage(id);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
