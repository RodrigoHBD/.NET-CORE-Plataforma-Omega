﻿using MercadoLivreService.App.Boundries.AccountDAO;
using MercadoLivreService.App.Models;
using MercadoLivreService.App.Models.Out;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Boundries.DAO
{
    public class AccountDAO
    {
        public static AccountDAOMethods Methods { get; } = new AccountDAOMethods();

        public static async Task<string> RegisterAccount(Account account)
        {
            try
            {
                await Collections.Accounts.InsertOneAsync(account);
                return account.Id.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task UpdateAccountTokens(string id, AccountTokens newTokens)
        {
            try
            {
                var timezone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
                var now = TimeZoneInfo.ConvertTime(DateTime.Now, timezone);
                var filter = Builders<Account>.Filter.Where(acc => acc.Id == ObjectId.Parse(id));
                var update = Builders<Account>.Update
                    .Set(acc => acc.Tokens.AccessToken, newTokens.AccessToken)
                    .Set(acc => acc.Tokens.RefreshToken, newTokens.RefreshToken)
                    .Set(acc => acc.Dates.TokensLastRefreshedAt, now);

                await Collections.Accounts.FindOneAndUpdateAsync(filter, update);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static FilterDefinition<Account> BuildSearchFilter(SearchAccountsReq search)
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
                    nameFilter = Builders<Account>.Filter.Where(account => account.Name.Contains(search.Name.Value));
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

        public static async Task<bool> CheckIfAccountNameForUserIsTaken(string user, string accountName)
        {
            try
            {
                var filter = Builders<Account>.Filter.Where(account => account.Owner == user && account.Name == accountName);
                var count = await Collections.Accounts.CountDocumentsAsync(filter);
                var nameIsTaken = count > 0;
                return nameIsTaken;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<bool> CheckIfMercadoLivreIdExists(long id)
        {
            try
            {
                var filter = Builders<Account>.Filter.Where(account => account.MercadoLivreId == id);
                var count = await Collections.Accounts.CountDocumentsAsync(filter);
                var exist = count > 0;
                return exist;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<bool> CheckIdExists(string id)
        {
            try
            {
                var filter = Builders<Account>.Filter.Where(account => account.Id == ObjectId.Parse(id));
                var count = await Collections.Accounts.CountDocumentsAsync(filter);
                var exist = count > 0;
                return exist;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task UpdateAccount(string id, AccountUpdate request)
        {
            try
            {
                if (request.Email.MustUpdate)
                {
                    await UpdateEmail(id, request.Email.Value);
                }
                if (request.Nickname.MustUpdate)
                {
                    await UpdateNickname(id, request.Nickname.Value);
                }
                if (request.Name.MustUpdate)
                {
                    await UpdateName(id, request.Name.Value);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        private static async Task UpdateEmail(string id, string email)
        {
            try
            {
                var filter = Builders<Account>.Filter.Where(acc => acc.Id == ObjectId.Parse(id));
                var update = Builders<Account>.Update.Set(acc => acc.Email, email);
                await Collections.Accounts.FindOneAndUpdateAsync(filter, update);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static async Task UpdateNickname(string id, string nickname)
        {
            try
            {
                var filter = Builders<Account>.Filter.Where(acc => acc.Id == ObjectId.Parse(id));
                var update = Builders<Account>.Update.Set(acc => acc.Nickname, nickname);
                await Collections.Accounts.FindOneAndUpdateAsync(filter, update);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static async Task UpdateName(string id, string name)
        {
            try
            {
                var filter = Builders<Account>.Filter.Where(acc => acc.Id == ObjectId.Parse(id));
                var update = Builders<Account>.Update.Set(acc => acc.Name, name);
                await Collections.Accounts.FindOneAndUpdateAsync(filter, update);
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
