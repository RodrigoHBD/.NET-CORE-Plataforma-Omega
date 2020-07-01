using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.App.Models;

namespace UserService.App.Boundries.DAO
{
    public class UserDAO
    {
        public static async Task RegisterUserAsync(User user)
        {
            try
            {
                await Collections.Users.InsertOneAsync(user);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<bool> CheckUsernameExist(string username)
        {
            try
            {
                var filter = Builders<User>.Filter.Where(user => user.Username == username);
                var count = await Collections.Users.CountDocumentsAsync(filter);
                var exists = count > 0;
                return exists;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
