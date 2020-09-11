using MercadoLivreService.App.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Boundries.AccountDAO
{
    public class Get : AccountDAOMethod
    {
        public async Task<Account> ById(string id)
        {
            try
            {
                var filter = FilterBuilder.Where(acc => acc.Id == ObjectId.Parse(id));
                var query = await Collections.Accounts.FindAsync(filter);
                return query.FirstOrDefault();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Account> ByMercadoLivreId(long id)
        {
            try
            {
                var filter = FilterBuilder.Where(acc => acc.MercadoLivreId == id);
                var query = await Collections.Accounts.FindAsync(filter);
                return query.FirstOrDefault();
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
