using MercadoLivreService.App.Models;
using MercadoLivreService.App.Models.SearchFields;
using MercadoLivreService.gRPC.Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Controllers.Adapters
{
    public class GrpcSearchAccountReqAdapter
    {
        public static SearchAccountsReq Adapt(GrpcSearchAccountsReq grpcRequest)
        {
            try
            {
                return new SearchAccountsReq()
                {
                    Name = new StringSearchField(),
                    User = new StringSearchField(),
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
