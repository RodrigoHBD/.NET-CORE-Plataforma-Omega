using ShippingService.gRPC.Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Controller.TypeAdapters
{
    public class GrpcStringAdapter
    {
        public static string GetFrom(GrpcString req) => req.Value;
    }
}
