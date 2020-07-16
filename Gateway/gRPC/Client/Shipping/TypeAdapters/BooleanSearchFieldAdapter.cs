using Gateway.Controllers.Api.Models;
using Gateway.gRPC.Client.ShippingClientProto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.gRPC.Client.ShippingTypeAdapters
{
    public class BooleanSearchFieldAdapter
    {
        public static GrpcBooleanSearchField Adapt(BooleanSearchField field)
        {
            return new GrpcBooleanSearchField()
            {
                IsActive = field.IsActive,
                Value = field.Value
            };
        }
    }
}
