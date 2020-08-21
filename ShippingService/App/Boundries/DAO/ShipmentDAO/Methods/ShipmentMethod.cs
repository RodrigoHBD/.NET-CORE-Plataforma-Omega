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
        public static FilterDefinitionBuilder<Shipment> FilterBuilder { get { return Builders<Shipment>.Filter; } }

        public static UpdateDefinitionBuilder<Shipment> UpdateBuilder { get { return Builders<Shipment>.Update; } }
    }
}
