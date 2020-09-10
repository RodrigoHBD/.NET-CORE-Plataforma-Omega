using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShippingService.Correios;
using ShippingService.App.Models.ShipmentEvents;
using ShippingService.App.Boundries.MailerTypeAdapters.Output;
using ShippingService.App.Boundries.Shipping;

namespace ShippingService.App.Boundries
{
    public class ShippingBoundry
    {
        public enum Implementation
        {
            Unset,
            Correios,
            MercadoEnvios
        }

        public static async Task<PostedEvent> GetPostedEventAsync(string trackingCode, Implementation implementation)
        {
            try
            {
                if(implementation == Implementation.Correios)
                {
                    return await CorreiosImplementation.GetPostedEventAsync(trackingCode);
                }
                else
                {
                    return new PostedEvent();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static async Task<DeliveredEvent> GetDeliveredEventAsync(string trackingCode, Implementation implementation)
        {
            if (implementation == Implementation.Correios)
            {
                return await CorreiosImplementation.GetDeliveredEventAsync(trackingCode);
            }
            else
            {
                return new DeliveredEvent();
            }
        }

        public static async Task<AwaitingForPickUpEvent> GetAwaitingForPickUpEventAsync(string trackingCode, Implementation implementation)
        {
            if (implementation == Implementation.Correios)
            {
                return await CorreiosImplementation.GetAwaitingForPickUpEventAsync(trackingCode);
            }
            else
            {
                return new AwaitingForPickUpEvent();
            }
        }

        public static async Task<RejectedEvent> GetRejectedEventAsync(string trackingCode, Implementation implementation)
        {
            if (implementation == Implementation.Correios)
            {
                return await CorreiosImplementation.GetRejectedEventAsync(trackingCode);
            }
            else
            {
                return new RejectedEvent();
            }
        }

        public static async Task<List<ForwardingEvent>> GetForwardingEventListAsync(string trackingCode, Implementation implementation)
        {
            if (implementation == Implementation.Correios)
            {
                return await CorreiosImplementation.GetForwardingEventListAsync(trackingCode);
            }
            else
            {
                return new List<ForwardingEvent>();
            }
        }

        public static async Task<string> GetShipmentLastMessageAsync(string trackingCode, Implementation implementation)
        {
            if (implementation == Implementation.Correios)
            {
                return await CorreiosImplementation.GetShipmentLastMessageAsync(trackingCode);
            }
            else
            {
                return "";
            }
        }

    }
}
