using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.gRPC.Client
{
    public interface IGrpcClient
    {
        string UriAddress { get; }
    }
}
