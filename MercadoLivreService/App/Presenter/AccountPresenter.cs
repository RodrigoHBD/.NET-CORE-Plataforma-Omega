using MercadoLivreService.App.Models;
using MercadoLivreService.gRPC.Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Presenter
{
    public class AccountPresenter
    {
        public static GrpcAccount Present(Account account)
        {
            try
            {
                return new GrpcAccount()
                {
                    Id = account.Id.ToString(),
                    Name = account.Name,
                    Owner = account.Owner,
                    Description = account.Description,
                    AddedAt = account.Dates.AddedAt.ToString(),
                    LastSyncedAt = account.Dates.LastSyncedAt.ToString(),
                    IsSynced = account.States.IsSynced
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
