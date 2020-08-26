using ShippingService.App.Models;
using ShippingService.gRPC.Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Controller.TypeAdapters
{
    public class GrpcStringFilterAdapter
    {
        public static StringSearchFilter AdaptFrom(GrpcStringFilter req)
        {
            return new StringSearchFilter()
            {
                IsSet = req.IsActive,
                Value = req.Value
            };
        }
    }
}
