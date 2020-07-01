using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.App.Entities.UserDataFields;
using UserService.App.Models;

namespace UserService.App.Entities
{
    public class UserEntity
    {
        public static async Task ValidateNew(User user) 
        {
            try
            {
                await ValidateDataFieldsForNewUser(user);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static async Task ValidateDataFieldsForNewUser(User user)
        {
            try
            {
                await Username.ValidateNew(user.Username);
                await Password.Validate(user.Password);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
