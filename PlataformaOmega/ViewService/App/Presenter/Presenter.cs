using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewService.gRPC.Server.Protos;

namespace ViewService.App
{
    public class Presenter
    {
        public static GrpcViewAsString PresentViewAsString(string view)
        {
            return new GrpcViewAsString()
            {
                Data = view
            };
        }
    }
}
