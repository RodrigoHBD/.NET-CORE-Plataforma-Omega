using Gateway.Controllers.Common.Models;
using Gateway.gRPC.Client.MercadoLivreProto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Controllers.Api.MercadoLivreAdapters
{
    public class GrpcPaginationOutAdapter
    {
        public static PaginationOut Adapt(GrpcPaginationOut pagination)
        {
            try
            {
                return new PaginationOut()
                {
                    Limit = pagination.Limit,
                    Offset = pagination.Offset,
                    Total = pagination.Total
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
