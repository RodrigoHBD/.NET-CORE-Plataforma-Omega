using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesService.App.Presenters;
using SalesService.App.TypeAdapters;
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
                var request = GrpcRegisterSaleRequestAdapter.Adapt(grpcRequest);
                await UseCaseOperator.RegisterNewSale(request);
                return Presenter.PresentStatusResponse(true);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
