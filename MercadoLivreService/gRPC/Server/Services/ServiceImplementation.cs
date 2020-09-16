using Grpc.Core;
using MercadoLivreService.App.Controllers;
using MercadoLivreService.App.UseCases;
using MercadoLivreService.App.UseCases.Tokens;
using MercadoLivreService.gRPC.Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.gRPC.Server
{
    public class ServiceImplementation : MercadoLivreGrpc.MercadoLivreGrpcBase
    {
        public override async Task<GrpcStatusResponse> AddNewAccount(GrpcAddAccountReq request, ServerCallContext context)
        {
            try
            {
                return await MainController.AddAccount(request);
            }
            catch (Exception e)
            {
                throw HandleException(e);
            }
        }

        public override async Task<GrpcStringResponse> GetAppId(GrpcVoid request, ServerCallContext context)
        {
            try
            {
                return await MainController.GetAppId();
            }
            catch (Exception e)
            {
                throw HandleException(e);
            }
        }

        public override async Task<GrpcStringResponse> GetAppToken(GrpcVoid request, ServerCallContext context)
        {
            try
            {
                return await MainController.GetAppToken();
            }
            catch (Exception e)
            {
                throw HandleException(e);
            }
        }

        public override async Task<GrpcAccountList> SearchAccounts(GrpcSearchAccountsReq request, ServerCallContext context)
        {
            try
            {
                return await MainController.SearchAccounts(request);
            }
            catch (Exception e)
            {
                throw HandleException(e);
            }
        }

        public override async Task<GrpcVoid> RefreshAccountTokens(GrpcGetByIdReq request, ServerCallContext context)
        {
            try
            {
                await TokensUseCases.Refresh.Execute(request.Id);
                return new GrpcVoid();
            }
            catch (Exception e)
            {
                throw HandleException(e);
            }
        }

        public override async Task<GrpcVoid> SearchRecentOrders(GrpcStringReq request, ServerCallContext context)
        {
            try
            {
                return await MainController.SearchRecentOrders(request);
            }
            catch (Exception e)
            {
                throw HandleException(e);
            }
        }

        public override async Task<GrpcOrder> GetOrderDetail(GrpcGetOrderDetailReq request, ServerCallContext context)
        {
            try
            {
                return await MainController.GetOrderDetails(request);
            }
            catch (Exception e)
            {
                throw HandleException(e);
            }
        }

        public override async Task<GrpcShipmentDetail> GetShipmentDetail(GrpcGetShipmentDetailReq request, ServerCallContext context)
        {
            try
            {
                return await MainController.GetShipmentDetails(request);
            }
            catch (Exception e)
            {
                throw HandleException(e);
            }
        }

        public override async Task<GrpcAccount> GetAccountByMarketplaceId(GrpcGetByIdReq request, ServerCallContext context)
        {
            try
            {
                return await MainController.GetAccountByMarketplaceId(request);
            }
            catch (Exception e)
            {
                throw HandleException(e);
            }
        }

        public override async Task<GrpcVoid> SendMessage(GrpcSendMessageReq request, ServerCallContext context)
        {
            try
            {
                return await MainController.SendMessage(request);
            }
            catch (Exception e)
            {
                throw HandleException(e);
            }
        }

        private RpcException HandleException(Exception e)
        {
            Console.WriteLine(e);
            return new RpcException(new Status(StatusCode.Internal, e.Message));
        }

    }
}
