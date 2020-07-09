using MercadoLivreService.App.Controllers.Adapters;
using MercadoLivreService.App.Presenter;
using MercadoLivreService.App.UseCases;
using MercadoLivreService.gRPC.Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
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
                await AccountUseCaseController.AddNewAccountAsync(request);

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
                var result = await AccountUseCaseController.SearchAccountsAsync(request);
                return AccountListPresenter.Present(result);
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

    }
}
