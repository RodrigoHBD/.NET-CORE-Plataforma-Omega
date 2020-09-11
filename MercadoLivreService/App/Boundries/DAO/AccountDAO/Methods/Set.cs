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
    }
}
