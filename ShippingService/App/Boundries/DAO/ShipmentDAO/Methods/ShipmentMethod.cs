using MongoDB.Driver;
using ShippingService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Boundries.ShipmentDAOMethods
{
    public class ShipmentDAOMethod
    {
        public FilterDefinitionBuilder<Shipment> FilterBuilder { get { return Builders<Shipment>.Filter; } }

        public UpdateDefinitionBuilder<Shipment> UpdateBuilder { get { return Builders<Shipment>.Update; } }
    }
}
