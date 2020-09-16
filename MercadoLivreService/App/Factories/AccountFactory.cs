using MercadoLivreService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Factories
{
    public class AccountFactory
    {
        public Account GetAccount()
        {
            try
            {
                return new Account()
                {
                    Name = Request.Name,
                    Description = Request.Description,
                    Owner = Request.Owner,
                    Dates = new AccountDates()
                    {
                        AddedAt = DateTime.UtcNow
                    }
                };
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public AccountFactory(AddAccountRequest request) => Request = request;

        private AddAccountRequest Request { get; }
    }
}
