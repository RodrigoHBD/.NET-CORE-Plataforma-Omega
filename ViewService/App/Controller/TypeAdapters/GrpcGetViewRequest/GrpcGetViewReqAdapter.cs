using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewService.gRPC.Server.Protos;

namespace ViewService.App.ControllerTypeAdapters
{
    public class GrpcGetViewReqAdapter
    {
        public static string GetPath(GrpcGetViewRequest request)
        {
            return request.Path;
        }
    }
}
