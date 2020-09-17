using ShippingService.App.Boundries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.UseCases
{
    public class GetIsMarketplaceSaleIdRegistered
    {
        public async Task<bool> Execute()
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

        public GetIsMarketplaceSaleIdRegistered(string id) => ShipmentId = id;

        private string ShipmentId { get; }
    }
}
