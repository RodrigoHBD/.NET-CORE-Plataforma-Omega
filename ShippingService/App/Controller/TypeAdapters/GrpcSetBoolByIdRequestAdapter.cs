using ShippingService.gRPC.Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Controller.TypeAdapters
{
    public class GrpcSetBoolByIdRequestAdapter
    {
        public GrpcSetBoolByIdRequestAdapter(GrpcSetBoolByIdRequest req)
        {
            Request = req;
        }

        private GrpcSetBoolByIdRequest Request { get; set; }
    }
}
