using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.App.Boundries.DAO;
using UserService.App.CustomExceptions;

namespace UserService.App.Entities.UserDataFields
{
    public class Password
    {
        private static int MaxLength { get; } = 40;
        private static int MinimumLength { get; } = 5;
        public static async Task Validate(string password)
        {
            try
            {
                var isWithinRange = password.Length <= MaxLength && password.Length >= MinimumLength;

                if (!isWithinRange)
                {
                    throw new ValidationException("senha", $"Tamanho deve estar entre {MinimumLength} e {MaxLength} caracteres");
                }
                
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
