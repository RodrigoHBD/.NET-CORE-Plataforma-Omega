using MercadoLivreService.App.Controllers.Adapters;
using MercadoLivreService.App.Presenter;
using MercadoLivreService.App.UseCases;
using MercadoLivreService.gRPC.Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;


namespace MercadoLivreService.App.Controllers
{
    public class MainController
    {
        public static async Task<GrpcStatusResponse> AddAccount(GrpcAddAccountReq grpcRequest)
        {
            try
            {
                var request = GrpcAddAccountReqAdapter.Adapt(grpcRequest);
                await AccountUseCases.Create(request).Execute();

                return new GrpcStatusResponse()
                {
                    Ok = true
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<GrpcAccountList> SearchAccounts(GrpcSearchAccountsReq grpcRequest)
        {
            try
            {
                var request = GrpcSearchAccountReqAdapter.Adapt(grpcRequest);
                var result = await AccountUseCases.Search.Execute(request);
                return AccountListPresenter.Present(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<GrpcVoid> SearchRecentOrders(GrpcStringReq grpcRequest)
        {
            try
            {
                var id = GrpcStringReqAdapter.GetStringData(grpcRequest);
                await OrderUseCaseController.CheckAllRecentOrders(id);
                return new GrpcVoid();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<GrpcOrder> GetOrderDetails(GrpcGetOrderDetailReq grpcRequest)
        {
            try
            {
                var orderId = grpcRequest.OrderId;
                var accountId = grpcRequest.AccountId;
                var json = await OrderUseCases.GetDetails.Execute(accountId, orderId);
                return OrderDetailPresenter.Present(json);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<GrpcAccount> GetAccountByMarketplaceId(GrpcGetByIdReq grpcRequest)
        {
            try
            {
                var id = GrpcGetByIdReqAdapter.Adapt(grpcRequest);
                var parsedId = Int64.Parse(id);
                var account = await AccountUseCases.Get.ByMercadoLivreId(parsedId);
                return AccountPresenter.Present(account);
            }
            catch (Exception)
            { 
                throw;
            }
        }

        public static async Task<GrpcStringResponse> GetAppId()
        {
            try
            {
                var id = UseCases.GetAppId.Execute();
                return new GrpcStringResponse()
                {
                    Data = id
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<GrpcStringResponse> GetAppToken()
        {
            try
            {
                var token = UseCases.GetAppToken.Execute();
                return new GrpcStringResponse()
                {
                    Data = token
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<GrpcShipmentDetail> GetShipmentDetails(GrpcGetShipmentDetailReq grpcRequest)
        {
            try
            {
                var accountId = grpcRequest.AccountId;
                var shipmentId = grpcRequest.ShipmentId;
                var json = await ShipmentUseCases.GetDetails.Execute(accountId, shipmentId);
                return ShipmentDetailPresenter.Present(json);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<GrpcVoid> SendMessage(GrpcSendMessageReq req)
        {
            try
            {
                var accountId = req.AccountId;
                var orderId = req.OrderId;
                var message = req.MessageText;
                await MessageUseCases.SendPostSaleMessage.Execute(accountId, orderId, message);
                return Empity;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private static GrpcVoid Empity { get; } = new GrpcVoid();

    }
}
