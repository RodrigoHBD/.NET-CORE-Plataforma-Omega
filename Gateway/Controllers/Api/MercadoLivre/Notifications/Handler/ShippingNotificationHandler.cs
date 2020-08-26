using Gateway.Controllers.Api.MercadoLivreModels.Input;
using Gateway.gRPC.Client;
using Gateway.gRPC.Client.MercadoLivreProto;
using Gateway.gRPC.Client.Sale;
using Gateway.gRPC.Client.SaleClientProto;
using Gateway.gRPC.Client.ShippingClientProto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Gateway.Controllers.Api.MercadoLivre.Notifications
{
    public class ShippingNotificationHandler : INotificationHandler
    {
        public bool TestShouldHandle(Notification notification)
        {
            if(notification.topic == "shipments")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task Handle(Notification notification)
        {
            try
            {
                await SetProperties(notification);

                var saleIsRegistered = await CheckIfSaleIsRegistered(MLShipment.OrderId.ToString());
                var trackingCodeAvailable = MLShipment.TrackingCode.Length > 0;

                if (!saleIsRegistered)
                {
                    SaleId = await RegisterSale(AccountId, MLShipment.OrderId);
                }
                else
                {
                    await GetSaleDetail();
                    SaleId = SaleDetail.Id;
                }

                if (trackingCodeAvailable)
                {
                    await CreateShipment();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private Notification Notification { get; set; }

        private long AccountId { get; set; }

        private long ShipmentId { get; set; }

        private string SaleId { get; set; }

        private GrpcShipmentDetail MLShipment { get; set; }

        private GrpcSale SaleDetail { get; set; }

        private async Task GetSaleDetail()
        {
            var request = new gRPC.Client.SaleClientProto.GrpcStringMessage()
            {
                Value = SaleId
            };
            SaleDetail = await SaleClient.GetByMarketplaceId(request);
        }

        private async Task CreateShipment()
        {
            try
            {
                var req = new GrpcNewShipmentRequest()
                {
                    TrackingCode = MLShipment.TrackingCode,
                    SetAutoUpdate = true,
                    MarketplaceAccountId = AccountId.ToString(),
                    MarketplaceSaleId = SaleId,
                    BoundMarketplace = "mercado livre",
                    SetCreatedManually = false,
                    ShippingImplementation = GetShipmentImplementation(),
                    PackageData = new GrpcNewPackageRequest()
                };
                await ShippingClient.CreateShipment(req);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string GetShipmentImplementation()
        {
            try
            {
                var shippingMethod = MLShipment.TrackingMethod;

                if(shippingMethod == "Jadlog Normal")
                {
                    return "Mercado Envios";
                }
                else if(shippingMethod == "PAC")
                {
                    return "Correios";
                }
                else
                {
                    return $"Indefinido - {shippingMethod}";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task SetProperties(Notification notification)
        {
            Notification = notification;
            ShipmentId = Int64.Parse(Regex.Replace(Notification.resource, "[^.0-9]", ""));
            AccountId = Notification.user_id;
            MLShipment = await GetBoundryShipmentDetails();
            SaleId = MLShipment.OrderId.ToString();
        }

        private async Task<bool> CheckIfSaleIsRegistered(string id)
        {
            var req = new GrpcString() { Value = id };
            var isRegistered = await ShippingClient.GetIsMarketplaceSaleIdRegistered(req);
            return isRegistered.Value;
        }

        private async Task<string> RegisterSale(long accountId, long orderId)
        {
            var orderDetails = await GetSaleDetails(accountId, orderId);
            var request = CreateRegisterSaleRequest(orderDetails);
            var response = await SaleClient.RegisterNewSale(request);
            return response.Message;
        }

        private GrpcRegisteSaleRequest CreateRegisterSaleRequest(GrpcOrder order)
        {
            return new GrpcRegisteSaleRequest()
            {
                Plataform = "mercado livre",
                PlatformSaleId = order.Id.ToString(),
                QuantitySold = 1,
                Status = "pending"
            };
        }

        private async Task<GrpcOrder> GetSaleDetails(long accountId, long orderId)
        {
            var request = new GrpcGetOrderDetailReq()
            {
                AccountId = accountId,
                OrderId = orderId
            };
            return await MercadoLivreClient.GetOrderDetail(request);
        }

        private async Task<GrpcShipmentDetail> GetBoundryShipmentDetails()
        {
            var request = new GrpcGetShipmentDetailReq() { AccountId = AccountId, ShipmentId = ShipmentId };
            var shipmentDetails = await MercadoLivreClient.GetShipmentDetail(request);
            return shipmentDetails;

        }
    }
}
