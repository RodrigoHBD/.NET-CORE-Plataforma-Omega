using MercadoLivreService.App.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Boundries.AccountDAO
{
    public class AccountDAOMethod
    {
        public FilterDefinitionBuilder<Account> FilterBuilder { get; } = Builders<Account>.Filter;

        public SortDefinitionBuilder<Account> SortBuilder { get; } = Builders<Account>.Sort;
    }
}
