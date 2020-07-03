using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.App.Boundries.DAO;
using UserService.App.Models;

namespace UserService.App.UseCases
{
    public class RegisterUser
    {
        public static async Task Execute(User user)
        {
            try
            {
                await UserDAO.RegisterUserAsync(user);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
