using ShippingService.App.Boundries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Entities.ShipmentDataField
{
    public class ShipmentTrackingCode
    {
        public async Task ValidateNew(string code)
        {
            try
            {
                var exists = await ShipmentDAO.Methods.GetBy.TrackingCodeBool(code);

                if (exists)
                {
                    throw new Exception("Codigo de rastreio ja registrado.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
