using MercadoLivreService.App.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Entities.AccountDataFields
{
    public class AccessToken
    {
        private static int MinLength { get; } = 1;

        public static void Validate(string token = "")
        {
            try
            {
                var isInRange = token.Length > MinLength;

                if (!isInRange)
                {
                    throw new ValidationException("Access Token", "Access Token vazio.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
