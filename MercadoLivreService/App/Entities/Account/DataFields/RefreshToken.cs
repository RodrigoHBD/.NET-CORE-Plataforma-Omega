using MercadoLivreService.App.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Entities.AccountDataFields
{
    public class RefreshToken
    {
        private static int MinLength { get; } = 1;

        public static void Validate(string token = "")
        {
            try
            {
                var isInRange = token.Length > MinLength;

                if (!isInRange)
                {
                    throw new ValidationException("Refresh Token", "Refresh Token vazio.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
