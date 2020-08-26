using Gateway.Controllers.Common.Models;
using Gateway.gRPC.Client.ShippingClientProto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.gRPC.Client.ShippingTypeAdapters
{
    public class BooleanSearchFieldAdapter
    {
        public static GrpcBooleanFilter Adapt(BooleanSearchFilter field)
        {
            return new GrpcBooleanFilter()
            {
                IsActive = field.IsActive,
                Value = field.Value
            };
        }
    }
}
