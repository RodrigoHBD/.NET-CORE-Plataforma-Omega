using Gateway.gRPC.Client.ViewClientProtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.App.Boundries.SCI.ViewFactories
{
    public class GrpcGetStaticFileRequestFactory
    {
        public static GrpcGetStaticFileRequest Make(string path)
        {
            return new GrpcGetStaticFileRequest()
            {
                Path = path
            };
        }
    }
}
