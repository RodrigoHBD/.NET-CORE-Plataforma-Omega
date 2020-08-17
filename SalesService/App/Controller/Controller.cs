using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesService.App.Controller.Adapters;
using SalesService.App.Presenters;
using SalesService.App.UseCases;
using SalesService.gRPC.Server.Protos;

namespace SalesService.App.Controller
{
    public class Controller
    {
        public static async Task<GrpcStatusResponse> RegisterNewSale(GrpcRegisteSaleRequest grpcRequest)
        {
            try
            {
                var request = SaleAdapters.RegisterSaleRequest.Adapt(grpcRequest);
                var id = await SaleUseCasesController.RegisterNewSaleAsync(request);
                return Presenter.PresentStatusResponse(true, id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task<GrpcSale> GetSaleByMarketplaceId(GrpcStringMessage grpcRequest)
        {
            try
            {
                var id = grpcRequest.Value;
                var sale = await SaleUseCases.GetSaleByMarketplaceId.Execute(id);
                return SalePresenter.Present(sale);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
