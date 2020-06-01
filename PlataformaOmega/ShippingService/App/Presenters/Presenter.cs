using ShippingService.gRPC.Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Presenters
{
    public class Presenter
    {
        public static GrpcStatusResponse PresentStatusResponse(bool status, string message = "")
        {
            return new GrpcStatusResponse()
            {
                Ok = status,
                Message = message
            };
        }
    }
}
