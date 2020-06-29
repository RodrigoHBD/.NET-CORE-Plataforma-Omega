using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.App.Boundries.DAO;
using UserService.App.CustomExceptions;
using UserService.App.Models;

namespace UserService.App.Entities.UserDataFields
{
    public class Username
    {
        private static int MaxLength { get; } = 40;
        private static int MinimumLength { get; } = 5;
        public static async Task ValidateNew(string username)
        {
            try
            {
                var usernameTaken = await UserDAO.CheckUsernameExist(username);
                var isWithinRange = username.Length <= MaxLength && username.Length >= MinimumLength;

                if (!isWithinRange)
                {
                    throw new ValidationException("username", $"Tamanho deve estar entre {MinimumLength} e {MaxLength} caracteres");
                }
                if (usernameTaken)
                {
                    throw new ValidationException("username", "Esse nome de usuario já está sendo usado, tente outro");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
