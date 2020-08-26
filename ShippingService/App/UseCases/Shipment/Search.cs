using ShippingService.App.Boundries;
using ShippingService.App.Models.Input;
using ShippingService.App.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.UseCases
{
    public class SearchShipment
    {
        public async Task<ShipmentList> Execute(ShipmentSearch search)
        {
            try
            {
                // TODO valdiate search object
                return await ShipmentDAO.Methods.Search(search);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public SearchShipment()
        {
            
        }
    }
}
