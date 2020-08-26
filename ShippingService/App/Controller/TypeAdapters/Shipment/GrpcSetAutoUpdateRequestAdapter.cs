using ShippingService.gRPC.Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Controller.TypeAdapters
{
    public class GrpcSetAutoUpdateRequestAdapter
    {
        public string GetId()
        {
            return Request.Id;
        }

        public bool GetBool()
        {
            return Request.Toggler;
        }
        
        public GrpcSetAutoUpdateRequestAdapter(GrpcSetAutoUpdateRequest req)
        {
            Request = req;
        }

        private GrpcSetAutoUpdateRequest Request { get; set; }
    }
}
