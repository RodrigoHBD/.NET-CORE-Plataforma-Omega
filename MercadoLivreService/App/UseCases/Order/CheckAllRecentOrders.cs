using MercadoLivreService.App.Models;
using MercadoLivreService.App.Models.In;
using MercadoLivreService.gRPC.Client;
using MercadoLivreService.MercadoLivre.Models;
using MercadoLivreService.MercadoLivreModels.Out;
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
                await SetInitialPagination();

                for(var i = 0; i < Pagination.Total; i++)
                {
                    var pagination = new PaginationIn() { Limit = 1, Offset = i };
                    var apiCallResponse = await MercadoLivreLib.Methods.Order.SearchRecentOrders(Account, pagination).Execute();
                    ValdiateResponse(apiCallResponse);
                    var data = apiCallResponse.DeserializedJson as OrderSearchJson;
                    var order = data.results[0];
                    await HanldeOrder(order, i);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private Account Account { get; set; }

        private Pagination Pagination { get; set; } = new Pagination() { Offset = 0, Total = 0 };

        private async Task SetAccount(string id)
        {
            Account = await AccountUseCases.GetById.Execute(id);
        }

        private async Task SetInitialPagination()
        {
            var pagination = new PaginationIn() { Offset = 0 };
            var apiCallResponse = await MercadoLivreLib.Methods.Order.SearchRecentOrders(Account, pagination).Execute();
            ValdiateResponse(apiCallResponse);
            var data = apiCallResponse.DeserializedJson as OrderSearchJson;
            Pagination.Total = data.paging.total;
            Pagination.Limit = 1;
        }

        private void ValdiateResponse(ApiCallResponse response)
        {
            if (!response.IsOk)
            {
                throw response.Exception;
            }
        }

        private async Task HanldeOrder(OrderDetailJson order, int i)
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
