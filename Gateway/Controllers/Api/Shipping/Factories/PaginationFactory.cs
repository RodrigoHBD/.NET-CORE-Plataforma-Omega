using Gateway.Controllers.Api.Shipping.Models.Output;
using Gateway.Controllers.Common.Models;
using Gateway.gRPC.Client.ShippingClientProto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Controllers.Api.Shipping.Factories
{
    public class PaginationFactory
    {
        public static GrpcPagination GetFrom(PaginationIn data)
        {
            return new GrpcPagination()
            {
                Limit = data.Limit,
                Offset = data.Offset
            };
        }
    }
}
