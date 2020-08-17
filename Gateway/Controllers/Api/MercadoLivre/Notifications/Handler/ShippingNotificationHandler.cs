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
        private Notification Notification { get; set; }
        private long AccountId { get; set; }
        private long ShipmentId { get; set; }
        private string OrderId { get; set; }
        private string SaleId { get; set; }
        private GrpcShipmentDetail ShipmentDetail { get; set; }
        private GrpcSale SaleDetail { get; set; }

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

                var saleIsRegistered = await CheckIfSaleIsRegistered(ShipmentDetail.OrderId.ToString());
                var trackingCodeAvailable = ShipmentDetail.TrackingCode.Length > 0;

                if (!saleIsRegistered)
                {
                    SaleId = await RegisterSale(AccountId, ShipmentDetail.OrderId);
                }
                else
                {
                    await GetSaleDetail();
                    SaleId = SaleDetail.Id;
                }

                if (trackingCodeAvailable)
                {
                    await CreatePackage();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task GetSaleDetail()
        {
            var request = new gRPC.Client.SaleClientProto.GrpcStringMessage()
            {
                Value = OrderId
            };
            SaleDetail = await SaleClient.GetByMarketplaceId(request);
        }

        private async Task CreatePackage()
        {
            var request = new GrpcShipPackageRequest()
            {
                CreatedManually = false,
                MarketplaceSaleId = ShipmentDetail.OrderId.ToString(),
                SaleId = SaleId,
                SetWatcher = true,
                TrackingCode = ShipmentDetail.TrackingCode,
                InitialLocation = new GrpcLocation(),
                MarketplaceAccountId = AccountId.ToString()
            };
            await ShippingClient.CreateNewPackage(request);
        }

        private async Task SetProperties(Notification notification)
        {
            Notification = notification;
            ShipmentId = Int64.Parse(Regex.Replace(Notification.resource, "[^.0-9]", ""));
            AccountId = Notification.user_id;
            ShipmentDetail = await GetShipmentDetails();
            OrderId = ShipmentDetail.OrderId.ToString();
        }

        private async Task<bool> CheckIfSaleIsRegistered(string id)
        {
            var request = CreateCheckMarketplaceSaleIdRequest(id);
            var response = await ShippingClient.CheckMarketplaceIdExists(request);
            return response.Value;
        }

        private gRPC.Client.ShippingClientProto.GrpcStringMessage CreateCheckMarketplaceSaleIdRequest(string id)
        {
            return new gRPC.Client.ShippingClientProto.GrpcStringMessage()
            {
                Value = id
            };
        }

        private async Task<string> RegisterSale(long accountId, long orderId)
        {
            var orderDetails = await GetOrderDetails(accountId, orderId);
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

        private async Task<GrpcOrder> GetOrderDetails(long accountId, long orderId)
        {
            var request = new GrpcGetOrderDetailReq()
            {
                AccountId = accountId,
                OrderId = orderId
            };
            return await MercadoLivreClient.GetOrderDetail(request);
        }

        private async Task<GrpcShipmentDetail> GetShipmentDetails()
        {
            var request = new GrpcGetShipmentDetailReq() { AccountId = AccountId, ShipmentId = ShipmentId };
            var shipmentDetails = await MercadoLivreClient.GetShipmentDetail(request);
            return shipmentDetails;

        }
    }
}
