using Gateway.Controllers.Api.MercadoLivreModels.Output;
using Gateway.gRPC.Client.MercadoLivreProto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Controllers.Api.MercadoLivreAdapters
{
    public class GrpcAccountAdapter
    {
        public static Account Adapt(GrpcAccount account)
        {
            try
            {
                return new Account()
                {
                    Id = account.Id,
                    Name = account.Name,
                    Description = account.Description,
                    Owner = account.Owner,
                    IsSynced = account.IsSynced,
                    LastSyncedAt = account.LastSyncedAt,
                    AddedAt = account.AddedAt,
                    Email = account.Email,
                    Nickname = account.Nickname
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
