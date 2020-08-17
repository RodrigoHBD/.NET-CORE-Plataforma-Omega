using ShippingService.App.Boundries;
using ShippingService.App.Models.ShipmentEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.UseCases
{
    public class ShipmentSet
    {
        public async Task PostedEvent(string id, PostedEvent @event)
        {
            await ShipmentDAO.Methods.UpdateSet.SetPostedEvent(id, @event);
        }

        public async Task AwaitingForPickUpEvent(string id, AwaitingForPickUpEvent @event)
        {
            await ShipmentDAO.Methods.UpdateSet.SetAwaitingForPickUpEvent(id, @event);
        }

        public async Task RejectedEvent(string id, RejectedEvent @event)
        {
            await ShipmentDAO.Methods.UpdateSet.SetRejectedEvent(id, @event);
        }

        public async Task DeliveredEvent(string id, DeliveredEvent @event)
        {
            await ShipmentDAO.Methods.UpdateSet.SetDeliveredEvent(id, @event);
        }

        public async Task ForwardingEventList(string id, List<ForwardingEvent> list)
        {
            await ShipmentDAO.Methods.UpdateSet.SetForwardingEventList(id, list);
        }
    }
}
