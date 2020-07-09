using MercadoLivreService.App.Boundries.DAO.Implementations;
using MercadoLivreService.App.Controllers.Implementations;
using MercadoLivreService.gRPC.Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Controllers.Adapters
{
    public class PaginationInAdapter
    {
        public static PaginationIn Adapt(GrpcPaginationIn pagination)
        {
            try
            {
                return new PaginationIn()
                {
                    Limit = pagination.Limit,
                    Offset = pagination.Offset
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
