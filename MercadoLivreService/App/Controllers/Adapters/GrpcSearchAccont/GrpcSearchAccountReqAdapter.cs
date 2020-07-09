using MercadoLivreService.App.Controllers.Implementations;
using MercadoLivreService.App.Models;
using MercadoLivreService.gRPC.Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Controllers.Adapters
{
    public class GrpcSearchAccountReqAdapter
    {
        public static ISearchAccountsReq Adapt(GrpcSearchAccountsReq grpcRequest)
        {
            try
            {
                return new SearchAccountsReq()
                {
                    Name = new StringSearchField(grpcRequest.Name),
                    User = new StringSearchField(grpcRequest.Owner),
                    Pagination = PaginationInAdapter.Adapt(grpcRequest.Pagination)
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
