using MercadoLivreService.App.Boundries.DAO.AccountDAOFactories;
using MercadoLivreService.App.Models;
using Microsoft.VisualBasic;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Boundries.DAO
{
    public class AccountDAO
    {
        public static async Task RegisterAccount(Account account)
        {
            try
            {
                await Collections.Accounts.InsertOneAsync(account);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<IAccountList> SearchAccounts(ISearchAccountsReq search)
        {
            try
            {
                var pagination = search.Pagination;
                var filter = BuildSearchFilter(search);

                var count = await CountAccounts(filter);
                var query = Collections.Accounts.Find(filter).Skip(pagination.Offset).Limit(pagination.Limit);
                
                return AccountListFactory.Make(search, query, count);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static FilterDefinition<Account> BuildSearchFilter(ISearchAccountsReq search)
        {
            try
            {
                var filter = Builders<Account>.Filter.Empty;
                var ownerFilter = Builders<Account>.Filter.Empty;
                var nameFilter = Builders<Account>.Filter.Empty;

                if (search.User.IsActive)
                {
                    ownerFilter = Builders<Account>.Filter.Where(account => account.Owner == search.User.Value);
                }
                if (search.Name.IsActive)
                {
                    nameFilter = Builders<Account>.Filter.Where(account => account.Name == search.Name.Value);
                }
                filter = Builders<Account>.Filter.And(nameFilter, ownerFilter);

                return filter;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static async Task<long> CountAccounts(FilterDefinition<Account> filter)
        {
            try
            {
                return await Collections.Accounts.CountDocumentsAsync(filter);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
