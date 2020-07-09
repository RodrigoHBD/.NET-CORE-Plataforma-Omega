using MercadoLivreService.App.Models;
using MercadoLivreService.gRPC.Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Presenter
{
    public class PaginationOutPresenter
    {
        public static GrpcPaginationOut Present(IPaginationOut pagination)
        {
            try
            {
                return new GrpcPaginationOut()
                {
                    Limit = pagination.Limit,
                    Offset = pagination.Offset,
                    Total = (int)pagination.Total
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
