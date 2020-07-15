using MercadoLivreService.gRPC.Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Controllers.Adapters
{
    public class GrpcStringReqAdapter
    {
        public static string GetStringData(GrpcStringReq req)
        {
            return req.Data;
        }
    }
}
