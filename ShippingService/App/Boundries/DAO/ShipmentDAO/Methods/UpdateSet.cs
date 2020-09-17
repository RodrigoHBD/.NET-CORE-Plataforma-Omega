using MongoDB.Bson;
using MongoDB.Driver;
using ShippingService.App.Models.ShipmentEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Boundries.ShipmentDAOMethods
{
    public class UpdateSet : ShipmentDAOMethod
    {
        public async Task SetPostedEvent(string id, PostedEvent @event)
        {
            var filter = FilterBuilder.Where(shipment => shipment.Id == ObjectId.Parse(id));
            var update = UpdateBuilder.Set(shipment => shipment.PostedEvent, @event);
            await Collections.Shipments.UpdateOneAsync(filter, update);
        }

        public async Task SetAwaitingForPickUpEvent(string id, AwaitingForPickUpEvent @event)
        {
            var filter = FilterBuilder.Where(shipment => shipment.Id == ObjectId.Parse(id));
            var update = UpdateBuilder.Set(shipment => shipment.AwaitingForPickUpEvent, @event);
            await Collections.Shipments.UpdateOneAsync(filter, update);
        }

        public async Task SetDeliveredEvent(string id, DeliveredEvent @event)
        {
            var filter = FilterBuilder.Where(shipment => shipment.Id == ObjectId.Parse(id));
            var update = UpdateBuilder.Set(shipment => shipment.DeliveredEvent, @event);
            await Collections.Shipments.UpdateOneAsync(filter, update);
        }

        public async Task SetRejectedEvent(string id, RejectedEvent @event)
        {
            var filter = FilterBuilder.Where(shipment => shipment.Id == ObjectId.Parse(id));
            var update = UpdateBuilder.Set(shipment => shipment.RejectedEvent, @event);
            await Collections.Shipments.UpdateOneAsync(filter, update);
        }

        public async Task SetForwardingEventList(string id, List<ForwardingEvent> list)
        {
            var filter = FilterBuilder.Where(shipment => shipment.Id == ObjectId.Parse(id));
            var update = UpdateBuilder.Set(shipment => shipment.ForwardingEvents, list);
            await Collections.Shipments.UpdateOneAsync(filter, update);
        }

        public async Task PushToForwardingEventList(string id, ForwardingEvent @event)
        {
            var filter = FilterBuilder.Where(shipment => shipment.Id == ObjectId.Parse(id));
            var update = UpdateBuilder.Push(shipment => shipment.ForwardingEvents, @event);
            await Collections.Shipments.UpdateOneAsync(filter, update);
        }

        public async Task BoundryMessage(string id, string message)
        {
            var filter = FilterBuilder.Where(shipment => shipment.Id == ObjectId.Parse(id));
            var update = UpdateBuilder.Set(shipment => shipment.BoundryMessage, message);
            await Collections.Shipments.UpdateOneAsync(filter, update);
        }

        public async Task PackageId(string id, string packageId)
        {
            try
            {
                var filter = FilterBuilder.Where(shipment => shipment.Id == ObjectId.Parse(id));
                var update = UpdateBuilder.Set(shipment => shipment.PackageId, packageId);
                await Collections.Shipments.UpdateOneAsync(filter, update);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task AutoUpdate(string id, bool toggle)
        {
            try
            {
                var filter = FilterBuilder.Where(shipment => shipment.Id == ObjectId.Parse(id));
                var update = UpdateBuilder.Set(shipment => shipment.AutoUpdate, toggle);
                await Collections.Shipments.UpdateOneAsync(filter, update);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task PostedEventNotified(string id, bool toggle)
        {
            try
            {
                var filter = FilterBuilder.Where(shipment => shipment.Id == ObjectId.Parse(id));
                var update = UpdateBuilder
                    .Set(shipment => shipment.PostedEvent.IsUserNotified, toggle)
                    .Set(shipment => shipment.PostedEvent.Dates.UserLastNotifiedAt, DateTime.UtcNow);
                await Collections.Shipments.UpdateOneAsync(filter, update);
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
