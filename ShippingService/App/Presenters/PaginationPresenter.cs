using ShippingService.App.Models;
using ShippingService.gRPC.Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Presenters
{
    public class PaginationPresenter
    {
        public static GrpcPagination Present(PaginationOut @out)
        {
            return new GrpcPagination()
            {
                Offset = @out.Offset,
                Limit = @out.Limit,
                Total = @out.Total
            };
        }
    }
}
