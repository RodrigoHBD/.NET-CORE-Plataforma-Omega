using MercadoLivreService.App.Boundries.AccountDAO;
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
