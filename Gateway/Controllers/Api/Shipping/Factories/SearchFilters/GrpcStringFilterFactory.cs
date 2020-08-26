using Gateway.Controllers.Common.Models;
using Gateway.gRPC.Client.ShippingClientProto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Controllers.Api.Shipping.Factories
{
    public class GrpcStringFilterFactory
    {
        public static GrpcStringFilter GetFrom(StringSearchFilter filter)
        {
            return new GrpcStringFilter()
            {
                IsActive = filter.IsActive,
                Value = filter.Value
            };
        }
    }
}
