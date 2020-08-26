using ShippingService.App.Boundries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Entities.ShipmentMethods
{
    public class ValidateMarketplaceData
    {
        public async Task ValdiateMarketplaceSaleId(string id)
        {
            try
            {
                var count = await ShipmentDAO.Methods.Count.MarketplaceSaleId(id);
                var isRegistered = count > 0;

                if (isRegistered)
                {
                    throw new Exception("");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> GetIsMarketplaceSaleIdRegistered(string id)
        {
            try
            {
                var count = await ShipmentDAO.Methods.Count.MarketplaceSaleId(id);
                var isRegistered = count > 0;
                return isRegistered;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
