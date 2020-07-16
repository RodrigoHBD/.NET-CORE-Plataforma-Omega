using Gateway.Controllers.Api.MercadoLivreModels.Input;
using Gateway.gRPC.Client.MercadoLivreProto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Controllers.Api.MercadoLivreAdapter
{
    public class AddAccountReqAdapter
    {
        public static GrpcAddAccountReq AdaptToGrpc(AddAccountReq req)
        {
            return new GrpcAddAccountReq()
            {
                AuthCode = req.AuthCode,
                Name = req.Name,
                Description = req.Description
            };
        }
    }
}
