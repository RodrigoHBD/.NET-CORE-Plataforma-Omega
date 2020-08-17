using SalesService.App.Entities;
using SalesService.App.Models;
using SalesService.gRPC.Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesService.App.Presenters
{
    public class SalePresenter
    {
        public static GrpcSale Present(Sale sale)
        {
            return new GrpcSale()
            {
                CreatedAt = sale.CreatedAt.ToString(),
                Id = sale.Id.ToString(),
                PlatformId = sale.PlatformSaleId,
                Status = SaleEntity.StatusToString(sale.Status)
            };
        }
    }
}
