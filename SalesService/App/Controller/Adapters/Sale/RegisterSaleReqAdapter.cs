using SalesService.App.Entities.SaleDataFields;
using SalesService.App.Models;
using SalesService.App.Models.Input;
using SalesService.gRPC.Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesService.App.Controller.Adapters
{
    public class RegisterSaleReqAdapter
    {
        public RegisterSaleRequest Adapt(GrpcRegisteSaleRequest grpcRequest)
        {
			try
			{
				var request = new RegisterSaleRequest()
				{
					ProductId = grpcRequest.ProductId,
					QuantitySold = grpcRequest.QuantitySold,
					Plataform = grpcRequest.Plataform,
					Status = DetermineStatus(grpcRequest.Status)
				};

				return request;
			}
			catch (Exception)
			{
				throw;
			}
        }

		private SaleStatus DetermineStatus(string status)
		{
			 return StatusEntity.Parse(status);
		}
    }
}
