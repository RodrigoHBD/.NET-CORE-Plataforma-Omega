using Gateway.Controllers.Common.Models;
using Gateway.gRPC.Client.ShippingClientProto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Controllers.Api.Shipping.Presenter
{
    public class PaginationPresenter
    {
        public static PaginationOut PresentFrom(GrpcPagination pagination)
        {
            return new PaginationOut()
            {
                Limit = pagination.Limit,
                Offset = pagination.Offset,
                Total = pagination.Total
            };
        }
    }
}
