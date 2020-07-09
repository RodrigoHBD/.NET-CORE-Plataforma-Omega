using Gateway.Controllers.Api.MercadoLivreModels.Output;
using Gateway.gRPC.Client.MercadoLivreProto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Gateway.Controllers.Api.MercadoLivreAdapters
{
    public class GrpcAccountListAdapter
    {
        private static AccountList Adapt(GrpcAccountList grpcAccountList)
        {
            try
            {
                var list = new AccountList()
                {
                    Pagination = GrpcPaginationOutAdapter.Adapt(grpcAccountList.Pagination)
                };

                grpcAccountList.Accounts.ToList().ForEach(acc => 
                {
                    list.Accounts.Add(GrpcAccountAdapter.Adapt(acc)); 
                });

                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string AdaptSerialized(GrpcAccountList grpcAccountList)
        {
            try
            {
                var list = Adapt(grpcAccountList);
                return JsonSerializer.Serialize(list);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
