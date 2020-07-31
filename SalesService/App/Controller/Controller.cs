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
                await SaleUseCasesController.RegisterNewSaleAsync(request);
                return Presenter.PresentStatusResponse(true);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
