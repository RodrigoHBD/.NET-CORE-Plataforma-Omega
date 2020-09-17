using ShippingService.App.Boundries;
using ShippingService.App.Models;
using ShippingService.gRPC.Client.MercadoLivre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.UseCases
{
    public class SendMessage
    {
        public async Task Execute(Shipment shipment, string message)
        {
            try
            {
                if(shipment.MarketplaceData.BoundMarketplace == "mercado livre")
                {
                    await SendMercadoLivreMessage(shipment, message);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task SendMercadoLivreMessage(Shipment shipment, string message)
        {
            var orderId = Int64.Parse(shipment.MarketplaceData.SaleId);
            var accountId = Int64.Parse(shipment.MarketplaceData.AccountId);
            var req = new GrpcSendMessageReq() 
            { AccountId = accountId, OrderId = orderId, MessageText = message };
            await MercadoLivreClient.SendMessage(req);
        }
    }
}
