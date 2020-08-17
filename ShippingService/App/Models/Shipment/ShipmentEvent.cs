using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Models
{
    public interface IShipmentEvent
    {
        string Title { get; }
        string Description { get; }
        ShipmentEventDates Dates { get; }
        ShipmentModifier GetModifiers();
    }

    public class ShipmentEventDates
    {
        public DateTime OccuredAt { get; set; }
    }

}
