using MercadoLivreService.gRPC.Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Controllers.Adapters
{
    public class GrpcGetByIdReqAdapter
    {
        public static string Adapt(GrpcGetByIdReq req)
        {
            return req.Id;
        }
    }
}
