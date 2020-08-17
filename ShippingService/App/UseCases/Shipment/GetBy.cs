using ShippingService.App.Boundries;
using ShippingService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.UseCases
{
    public class ShipmentGetBy
    {
        public async Task<Shipment> ByPackageId(string id)
        {
            return await ShipmentDAO.Methods.GetBy.PackageId(id);
        }
    }
}
