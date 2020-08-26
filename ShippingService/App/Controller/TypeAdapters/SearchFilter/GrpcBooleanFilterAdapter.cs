using ShippingService.App.Models;
using ShippingService.gRPC.Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Controller.TypeAdapters
{
    public class GrpcBooleanFilterAdapter
    {
        public static BoolSearchFilter AdaptFrom(GrpcBooleanFilter filter)
        {
            return new BoolSearchFilter()
            {
                IsSet = filter.IsActive,
                Value = filter.Value
            };
        }
    }
}
