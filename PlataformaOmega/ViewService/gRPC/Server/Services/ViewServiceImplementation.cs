using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewService.gRPC.Server.Protos;

namespace ViewService.gRPC.Server.Services
{
    public class ViewServiceImplementation : View.ViewBase
    {
        public override async Task<GrpcViewAsString> GetView(GrpcGetViewRequest request, ServerCallContext context)
        {
            
        }
    }
}
