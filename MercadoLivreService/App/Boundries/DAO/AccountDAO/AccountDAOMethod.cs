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

        public UpdateDefinitionBuilder<Account> UpdateBuilder { get; } = Builders<Account>.Update;

        public SortDefinitionBuilder<Account> SortBuilder { get; } = Builders<Account>.Sort;

        public TimeZoneInfo TimeZone { get; } = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");

        public DateTime GetNow() => TimeZoneInfo.ConvertTime(DateTime.Now, TimeZone);
    }
}
