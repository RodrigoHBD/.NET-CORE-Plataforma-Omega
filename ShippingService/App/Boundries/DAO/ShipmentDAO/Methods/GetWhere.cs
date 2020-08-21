using MongoDB.Driver;
using ShippingService.App.Models;
using ShippingService.App.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Boundries.ShipmentDAOMethods
{
    public class GetWhere : ShipmentDAOMethod
    {
        public async Task<ShipmentList> AutoUpdateIsSetTo(bool toggle, PaginationIn pagination)
        {
            try
            {
                var filter = FilterBuilder.Where(shipment => shipment.AutoUpdate == toggle);
                var query = Collections.Shipments.Find(filter).Limit(pagination.Limit).Skip(pagination.Offset);

                return new ShipmentList()
                {
                    Data = query.ToList(),
                    Pagination = new PaginationOut()
                    {
                        Limit = pagination.Limit,
                        Offset = pagination.Offset,
                        Total = await ShipmentDAO.Methods.Count.UsingFilter(filter)
                    }
                };
            }
            catch(Exception e)
            {
                throw;
            }
        }
    }
}
