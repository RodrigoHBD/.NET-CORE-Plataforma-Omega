using Gateway.gRPC.Client.ShippingClientProto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Controllers.Api.Shipping.Factories
{
    public class GrpcStringFactory
    {
        public static GrpcString From(string value) => new GrpcString() { Value = value };
    }
}
