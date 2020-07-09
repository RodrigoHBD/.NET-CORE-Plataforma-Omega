using Gateway.Controllers.Api.MercadoLivreModels.Input;
using Gateway.gRPC.Client.MercadoLivreProto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Controllers.Api.MercadoLivreAdapters
{
    public class SearchAccountsReqAdapter
    {
        public static GrpcSearchAccountsReq AdaptToGrpc(SearchAccountsReq request)
        {
            try
            {
                return new GrpcSearchAccountsReq()
                {
                    Name = request.Name,
                    Owner = request.Owner,
                    Pagination = new GrpcPaginationIn()
                    {
                        Limit = request.Pagination.Limit,
                        Offset = request.Pagination.Offset
                    }
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
