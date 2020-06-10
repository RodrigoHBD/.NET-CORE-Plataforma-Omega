using Gateway.gRPC.Client.ViewClientProtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.App.Boundries.SCI.ViewFactories
{
    public class GrpcGetViewRequestFactory
    {
        public static GrpcGetViewRequest Make(string path)
        {
            return new GrpcGetViewRequest()
            {
                Path = path
            };
        }
    }
}
