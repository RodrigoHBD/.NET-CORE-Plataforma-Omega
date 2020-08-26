using Gateway.Controllers.Common.Models;
using Gateway.gRPC.Client.ShippingClientProto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Controllers.Api.Shipping.Factories
{
    public class GrpcBooleanFilterFactory
    {
        public static GrpcBooleanFilter GetFrom(BooleanSearchFilter filter)
        {
            return new GrpcBooleanFilter()
            {
                IsActive = filter.IsActive,
                Value = filter.Value
            };
        }
    }
}
