using MercadoLivreService.App.Boundries.MercadoLivreModels;
using MercadoLivreService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.UseCases
{
    public class CreateAccount
    {
        public static Account Execute (IAddAccountRequest request, AuthCodeExchangeResult tokens)
        {
            try
            {
                return new Account()
                {
                    MercadoLivreId = tokens.UserId.ToString(),
                    Name = request.Name,
                    Description = request.Description,
                    Owner = request.Owner,
                    AccessToken = tokens.AccessToken,
                    RefreshToken = tokens.RefreshToken,
                    Dates = new AccountDates()
                    {
                        AddedAt = DateTime.UtcNow
                    }
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
