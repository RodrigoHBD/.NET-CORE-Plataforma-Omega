using MongoDB.Driver;
using ShippingService.App.Boundries.ShipmentDAOMethods;
using ShippingService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Boundries
{
    public class ShipmentDAO
    {
        public static Methods Methods { get; } = new Methods();
    }
}
