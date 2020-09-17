using ShippingService.App.Boundries;
using ShippingService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.UseCases
{
    public class NotifyUpdates
    {
        public async Task Execute()
        {
            try
            {
                var isDelivered = GetIsDelivered();

                if (!isDelivered)
                {
                    await NotifyEvents();
                }
            }
            catch (Exception e)
            {
                
            }
        }

        public NotifyUpdates(Shipment shipment) => Shipment = shipment;

        private Shipment Shipment { get; }

        private bool GetIsDelivered()
        {
            return Shipment.DeliveredEvent.IsDelivered;
        }

        private async Task NotifyEvents()
        {
            await NotifyPostedEvent();
        }

        private async Task NotifyPostedEvent()
        {
            var message = $"Monitoramento Automático: Seu envio de código de rastreio " +
                $"'{Shipment.TrackingCode}' foi postado na data '{Shipment.PostedEvent.Dates.OccurredAt}'. " +
                $"Atenciosamente, equipe Omega.";
            var isPosted = Shipment.PostedEvent.IsPosted;
            var isNotified = Shipment.PostedEvent.IsUserNotified;

            if (isPosted)
            {
                if (!isNotified)
                {
                    await Notify(message);
                    await ShipmentDAO.Methods.UpdateSet.PostedEventNotified(Shipment.Id.ToString(), true);
                }
            }
        }

        private async Task NotifyAwaitingForPickUpEvent()
        {
            var message = $"Monitoramento Automático: Seu envio de código de rastreio " +
                $"'{Shipment.TrackingCode}' foi postado na data '{Shipment.PostedEvent.Dates.OccurredAt}'. " +
                $"Atenciosamente, equipe Omega.";
            var isSet = Shipment.PostedEvent.IsPosted;
            var isNotified = Shipment.PostedEvent.IsUserNotified;
        }

        private async Task Notify(string message)
        {
            await MessageUseCases.SendMessage.Execute(Shipment, message);
        }
    }
}
