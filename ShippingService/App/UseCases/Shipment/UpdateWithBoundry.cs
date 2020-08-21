using ShippingService.App.Boundries;
using ShippingService.App.Entities.PackageDataField;
using ShippingService.App.Models;
using ShippingService.App.Models.ShipmentEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.UseCases
{
    public class UpdateShipmentWithBoundry
    {
        public async Task Execute()
        {
            try
            {
                await UpdatePostedEvent();
                await UpdateDelvieredEvent();
                await UpdateAwaitingForPickUpEvent();
                await UpdateRejectedEvent();
                await UpdateForwardingEvents();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UpdateShipmentWithBoundry(Shipment shipment)
        {
            TrackingCode = shipment.TrackingCode;
            Implementation = shipment.BoundryImplementation;
            Id = shipment.Id.ToString();
        }

        private ShippingBoundry.Implementation Implementation { get; }

        private string TrackingCode { get; }

        private string Id { get; }

        private async Task UpdatePostedEvent()
        {
            var @event = await ShippingBoundry.GetPostedEventAsync(TrackingCode, Implementation);
            await ShipmentDAO.Methods.UpdateSet.SetPostedEvent(Id, @event);
        }

        private async Task UpdateDelvieredEvent()
        {
            var @event = await ShippingBoundry.GetDeliveredEventAsync(TrackingCode, Implementation);
            await ShipmentDAO.Methods.UpdateSet.SetDeliveredEvent(Id, @event);
        }

        private async Task UpdateAwaitingForPickUpEvent()
        {
            var @event = await ShippingBoundry.GetAwaitingForPickUpEventAsync(TrackingCode, Implementation);
            await ShipmentDAO.Methods.UpdateSet.SetAwaitingForPickUpEvent(Id, @event);
        }

        private async Task UpdateRejectedEvent()
        {
            var @event = await ShippingBoundry.GetRejectedEventAsync(TrackingCode, Implementation);
            await ShipmentDAO.Methods.UpdateSet.SetRejectedEvent(Id, @event);
        }

        private async Task UpdateForwardingEvents()
        {
            var @eventList = await ShippingBoundry.GetForwardingEventListAsync(TrackingCode, Implementation);
            await ShipmentDAO.Methods.UpdateSet.SetForwardingEventList(Id, @eventList);
        }

    }
}
