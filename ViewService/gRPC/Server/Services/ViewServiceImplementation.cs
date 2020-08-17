using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewService.App;
using ViewService.gRPC.Server.Protos;

namespace ViewService.gRPC.Server.Services
{
    public class ViewServiceImplementation : View.ViewBase
    {
        public override async Task<GrpcViewAsString> GetView(GrpcGetViewRequest request, ServerCallContext context)
        {
            return await Controller.GetViewAsync(request);
        }

        public override async Task<GrpcViewAsString> GetStaticFile(GrpcGetStaticFileRequest request, ServerCallContext context)
        {
            return await Controller.GetStaticFileAsync(request);
        }

        public override async Task GetImageFile(GrpcGetStaticFileRequest request, IServerStreamWriter<GrpcStreamChunk> responseStream, ServerCallContext context)
        {
            
        }

    }
}
