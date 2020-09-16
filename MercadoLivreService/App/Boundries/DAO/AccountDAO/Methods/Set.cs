using MercadoLivreLibrary.Models;
using MercadoLivreService.App.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Boundries.AccountDAO
{
    public class Set : AccountDAOMethod
    {
        public async Task Tokens(string id, AccessTokensJson tokens)
        {
            try
            {
                var filter = FilterBuilder.Where(acc => acc.Id == ObjectId.Parse(id));
                var update = Builders<Account>.Update
                    .Set(acc => acc.Tokens.AccessToken, tokens.access_token)
                    .Set(acc => acc.Tokens.RefreshToken, tokens.refresh_token)
                    .Set(acc => acc.Dates.TokensLastRefreshedAt, GetNow());

                await Collections.Accounts.FindOneAndUpdateAsync(filter, update);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task MercadoLivreId(string id, long _id)
        {
            try
            {
                var filter = FilterBuilder.Where(acc => acc.Id == ObjectId.Parse(id));
                var update = UpdateBuilder.Set(acc => acc.MercadoLivreId, _id);
                await Collections.Accounts.FindOneAndUpdateAsync(filter, update);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task Email(string id, string email)
        {
            try
            {
                var filter = FilterBuilder.Where(acc => acc.Id == ObjectId.Parse(id));
                var update = UpdateBuilder.Set(acc => acc.Email, email);
                await Collections.Accounts.FindOneAndUpdateAsync(filter, update);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task Nickname(string id, string nickname)
        {
            try
            {
                var filter = FilterBuilder.Where(acc => acc.Id == ObjectId.Parse(id));
                var update = UpdateBuilder.Set(acc => acc.Nickname, nickname);
                await Collections.Accounts.FindOneAndUpdateAsync(filter, update);
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
