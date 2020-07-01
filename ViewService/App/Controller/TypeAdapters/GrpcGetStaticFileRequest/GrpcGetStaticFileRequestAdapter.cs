using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewService.gRPC.Server.Protos;

namespace ViewService.App.ControllerTypeAdapters
{
    public class GrpcGetStaticFileRequestAdapter
    {
        public static string GetPath(GrpcGetStaticFileRequest request)
        {
            return request.Path;
        }
    }
}
