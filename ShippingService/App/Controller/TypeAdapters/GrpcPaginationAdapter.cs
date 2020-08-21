using ShippingService.App.Models;
using ShippingService.gRPC.Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Controller.TypeAdapters
{
    public class GrpcPaginationAdapter
    {
        public static PaginationIn Adapt(GrpcPagination pagination)
        {
            return new PaginationIn()
            {
                Limit = pagination.Limit,
                Offset = pagination.Offset
            };
        }
    }
}
