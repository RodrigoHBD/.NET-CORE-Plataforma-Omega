using MercadoLivreService.App.Models;
using MercadoLivreService.App.Models.Out;
using MercadoLivreService.gRPC.Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Presenter
{
    public class AccountListPresenter
    {
        public static GrpcAccountList Present(AccountList accountList)
        {
            try
            {
                var presented = new GrpcAccountList()
                {
                    Pagination = PaginationOutPresenter.Present(accountList.Pagination)
                };
                accountList.Data.ForEach(acc => { presented.Accounts.Add( AccountPresenter.Present(acc) ); });
                return presented;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
