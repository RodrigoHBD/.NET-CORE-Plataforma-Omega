using MercadoLivreService.App.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Boundries.AccountDAO
{
    public class Count : AccountDAOMethod
    {
        public async Task<long> UsingFilter(FilterDefinition<Account> filter)
        {
            return await Collections.Accounts.CountDocumentsAsync(filter);
        }
    }
}
