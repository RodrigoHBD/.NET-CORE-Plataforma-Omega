using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShippingService.Correios;
using ShippingService.App.Models.ShipmentEvents;
using ShippingService.App.Boundries.MailerTypeAdapters.Output;

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
                var json = await CorreiosRastreamento.PegarDadosDeRastreamento(trackingCode);
                return SroResponseJsonAdapter.GetPostedEventFrom(json);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static async Task<DeliveredEvent> GetDeliveredEventAsync(string trackingCode, Implementation implementation)
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

        public static async Task<AwaitingForPickUpEvent> GetAwaitingForPickUpEventAsync(string trackingCode, Implementation implementation)
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

        public static async Task<RejectedEvent> GetRejectedEventAsync(string trackingCode, Implementation implementation)
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

        public static async Task<List<ForwardingEvent>> GetForwardingEventListAsync(string trackingCode, Implementation implementation)
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

    }
}
