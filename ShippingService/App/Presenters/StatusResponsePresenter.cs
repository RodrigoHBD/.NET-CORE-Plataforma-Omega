using ShippingService.gRPC.Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Presenters
{
    public class StatusResponsePresenter
    {
        public static GrpcStatusResponse Present(bool toggle, string message = "")
        {
            return new GrpcStatusResponse()
            {
                Ok = toggle,
                Message = message
            };
        }
    }
}
