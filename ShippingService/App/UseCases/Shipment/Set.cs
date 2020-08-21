using ShippingService.App.Boundries;
using ShippingService.App.Entities;
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
            await ShipmentEntity.ValidateId(id);
            await ShipmentDAO.Methods.UpdateSet.SetPostedEvent(id, @event);
        }

        public async Task AwaitingForPickUpEvent(string id, AwaitingForPickUpEvent @event)
        {
            await ShipmentEntity.ValidateId(id);
            await ShipmentDAO.Methods.UpdateSet.SetAwaitingForPickUpEvent(id, @event);
        }

        public async Task RejectedEvent(string id, RejectedEvent @event)
        {
            await ShipmentEntity.ValidateId(id);
            await ShipmentDAO.Methods.UpdateSet.SetRejectedEvent(id, @event);
        }

        public async Task DeliveredEvent(string id, DeliveredEvent @event)
        {
            await ShipmentEntity.ValidateId(id);
            await ShipmentDAO.Methods.UpdateSet.SetDeliveredEvent(id, @event);
        }

        public async Task ForwardingEventList(string id, List<ForwardingEvent> list)
        {
            await ShipmentEntity.ValidateId(id);
            await ShipmentDAO.Methods.UpdateSet.SetForwardingEventList(id, list);
        }

        public async Task PackageId(string id, string packageId)
        {
            try
            {
                await PackageEntity.ValidatePackageId(packageId);
                await ShipmentEntity.ValidateId(id);
                await ShipmentDAO.Methods.UpdateSet.PackageId(id, packageId);
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
                await ShipmentEntity.ValidateId(id);
                await ShipmentDAO.Methods.UpdateSet.AutoUpdate(id, toggle);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
