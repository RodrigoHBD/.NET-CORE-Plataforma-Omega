using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.App.Models;
using UserService.App.Models.Input;

namespace UserService.App.Factories
{
    public class UserFactory
    {
        public static User MakeUser(INewUserRequest request)
        {
            try
            {
                return new User()
                {
                    Username = request.Username,
                    Password = request.Password,
                    CreatedAt = DateTime.Now,
                    Name = request.Name,
                    LastName = request.LastName
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
