using Gateway.Controllers.Api.Shipping.Models.Output;
using Gateway.gRPC.Client.ShippingClientProto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Controllers.Api.Shipping.Factories
{
    public class PaginationFactory
    {
        public static Pagination Make(GrpcPagination data)
        {
            return new Pagination()
            {
                Limit = data.Limit,
                Offset = data.Offset,
                Total = data.Total
            };
        }
    }
}
