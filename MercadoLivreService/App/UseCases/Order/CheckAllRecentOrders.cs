using MercadoLivreLibrary;
using MercadoLivreLibrary.Models;
using MercadoLivreLibrary.Models.Input;
using MercadoLivreService.App.Models;
using MercadoLivreService.App.UseCases.Tokens;
using MercadoLivreService.gRPC.Client;
using MercadoLivreService.MercadoLivre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.UseCases
{
    public class CheckAllRecentOrders 
    {
        public async Task Execute(string id)
        {
            try
            {
                await SetAccount(id);
                await SetToken();
                await SetTotal();

                for (; Pagination.Offset < Total; Pagination.Offset++)
                {
                    var data = await Search();
                    await HandleSearch(data);
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private Account Account { get; set; }

        private string Token { get; set; }

        private Pagination Pagination { get; set; } = new Pagination() { Limit = 1 };

        private int Total { get; set; }

        private async Task SetAccount(string id) => Account = await AccountUseCases.Get.ById(id);

        private async Task SetToken() => 
            Token = await TokensUseCases.GetValidAccessToken.ForAccount(Account.MercadoLivreId);

        private async Task SetTotal()
        {
            var search = await MercadoLivreLib.Methods.Order
                .SearchRecentOrders(Account.MercadoLivreId, Token, Pagination).Execute();
            Total = search.paging.total;
        }

        private async Task<OrderSearchJson> Search()
        {
            return await MercadoLivreLib.Methods.Order
                .SearchRecentOrders(Account.MercadoLivreId, Token, Pagination).Execute();
        }

        private async Task HandleSearch(OrderSearchJson json)
        {
            json.results.ForEach(async order => 
            {
                await HanldeOrder(order);
            });
        }

        private async Task HanldeOrder(OrderDetailJson order)
        {
            await CreateShipment(order);
        }

        private async Task CreateShipment(OrderDetailJson order)
        {
            var isOrderRegistered = await GetIsOrderRegistered(order);
            var shipmentDetails = await GetShipmentDetails(order);
            var trackingCode = shipmentDetails.tracking_number;

            if (!isOrderRegistered && trackingCode != null)
            {
                var req = new gRPC.Client.ShippingClientProto.GrpcNewShipmentRequest()
                {
                    MarketplaceAccountId = Account.MercadoLivreId.ToString(),
                    TrackingCode = trackingCode,
                    SetAutoUpdate = true,
                    BoundMarketplace = "mercado livre",
                    MarketplaceSaleId = order.id.ToString(),
                    PackageData = new gRPC.Client.ShippingClientProto.GrpcNewPackageRequest(),
                    SetCreatedManually = false,
                    ShippingImplementation = GetShippingImplementation(shipmentDetails)
                };
                await ShippingClient.CreateShipment(req);
            }
        }

        private async Task<bool> GetIsOrderRegistered(OrderDetailJson order)
        {
            var req = new gRPC.Client.ShippingClientProto.GrpcString() { Value = order.id.ToString() };
            var resp = await ShippingClient.GetIsMarketplaceSaleIdRegistered(req);
            return resp.Value;
        }

        private async Task<ShipmentJson> GetShipmentDetails(OrderDetailJson order)
        {
            return await ShipmentUseCases.GetDetails.Execute(Account.MercadoLivreId, order.shipping.id);
        }

        private string GetShippingImplementation(ShipmentJson shipment)
        {
            var trackingMethod = shipment.tracking_method;

            if (trackingMethod == "Jadlog Normal")
            {
                return "mercado envios";
            }
            else if (trackingMethod == "PAC")
            {
                return "correios";
            }
            else
            {
                return $"Indefinido - {trackingMethod}";
            }
        }
    }
}
