using MercadoLivreService.App.CustomExceptions;
using MercadoLivreService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Entities.AccountDataFields
{
    public class Tokens
    {
        private static int MinLength { get; } = 1;

        public static void Validate(AccountTokens tokens)
        {
            try
            {
                var accessTokenIsInRange = tokens.AccessToken.Length > MinLength;
                var refreshTokenIsInRange = tokens.RefreshToken.Length > MinLength;
                var isInRange = accessTokenIsInRange && refreshTokenIsInRange;

                if (!isInRange)
                {
                    throw new ValidationException("Access Token or RefreshToken", "Token vazio.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
