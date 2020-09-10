using ShippingService.App.Boundries.MailerTypeAdapters.Output;
using ShippingService.App.Models.ShipmentEvents;
using ShippingService.Correios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Boundries.Shipping
{
    public class CorreiosImplementation
    {
        public static async Task<PostedEvent> GetPostedEventAsync(string trackingCode)
        {
            try
            {
                var json = await CorreiosRastreamento.PegarDadosDeRastreamento(trackingCode);
                return SroResponseJsonAdapter.GetPostedEventFrom(json);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static async Task<DeliveredEvent> GetDeliveredEventAsync(string trackingCode)
        {
            try
            {
                var json = await CorreiosRastreamento.PegarDadosDeRastreamento(trackingCode);
                return SroResponseJsonAdapter.GetDeliveredEventFrom(json);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static async Task<AwaitingForPickUpEvent> GetAwaitingForPickUpEventAsync(string trackingCode)
        {
            try
            {
                var json = await CorreiosRastreamento.PegarDadosDeRastreamento(trackingCode);
                return SroResponseJsonAdapter.GetAwaitingForPickUpEventFrom(json);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static async Task<RejectedEvent> GetRejectedEventAsync(string trackingCode)
        {
            try
            {
                var json = await CorreiosRastreamento.PegarDadosDeRastreamento(trackingCode);
                return SroResponseJsonAdapter.GetRejectedEventFrom(json);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static async Task<List<ForwardingEvent>> GetForwardingEventListAsync(string trackingCode)
        {
            try
            {
                var json = await CorreiosRastreamento.PegarDadosDeRastreamento(trackingCode);
                return SroResponseJsonAdapter.GetForwardingEventListFrom(json);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static async Task<string> GetShipmentLastMessageAsync(string trackingCode)
        {
            try
            {
                var json = await CorreiosRastreamento.PegarDadosDeRastreamento(trackingCode);
                return SroResponseJsonAdapter.GetLastMessageFrom(json);
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
