using MercadoLivreService.App.Boundries.DAO.Implementations;
using MercadoLivreService.App.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Boundries.DAO.AccountDAOFactories
{
    public class AccountListFactory
    {
        public static AccountList Make(ISearchAccountsReq request, IFindFluent<Account, Account> query,  long count)
        {
            try
            {
                var pagination = request.Pagination;
                return new AccountList()
                {
                    Accounts = query.ToList(),
                    Pagination = new Pagination()
                    {
                        Limit = pagination.Limit,
                        Offset = pagination.Offset,
                        Total = count
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
