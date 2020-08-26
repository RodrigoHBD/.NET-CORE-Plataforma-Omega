using ShippingService.App.Boundries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.UseCases
{
    public class Get
    {
        public async Task<bool> IsMarketplaceSaleIdRegistered()
        {
            try
            {
                var count = await ShipmentDAO.Methods.Count.MarketplaceSaleId(ShipmentId);
                var isRegistered = count > 0;
                return isRegistered;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Get(string id) => ShipmentId = id;

        private string ShipmentId { get; }
    }
}
