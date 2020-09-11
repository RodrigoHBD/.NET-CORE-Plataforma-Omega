using MercadoLivreService.App.Models;
using MercadoLivreService.App.Models.Out;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Boundries.AccountDAO
{
    public class Search : AccountDAOMethod
    {
        public async Task<AccountList> Execute()
        {
            try
            {
                SetFilter();
                SetSort();
                SetPagination();
                return await GetData();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Search(SearchAccountsReq req) => Request = req;

        private SearchAccountsReq Request { get; }

        private FilterDefinition<Account> Filter { get; set; } 

        private SortDefinition<Account> Sort { get; set; }

        private int Offset { get; set; }

        private int Limit { get; set; }

        private void SetFilter()
        {
            Filter = FilterBuilder.Empty;
        }

        private void SetSort()
        {
            Sort = SortBuilder.Descending(acc => acc.Dates.AddedAt);
        }

        private void SetPagination()
        {
            Offset = Request.Pagination.Offset;
            Limit = Request.Pagination.Limit;
        }

        private async Task<AccountList> GetData()
        {
            return new AccountList()
            {
                Data = GetAccounts(),
                Pagination = await GetPagination()
            };
        }

        private List<Account> GetAccounts()
        {
            var query = Collections.Accounts.Find(Filter).Sort(Sort).Skip(Offset).Limit(Offset);
            return query.ToList();
        }

        private async Task<PaginationOut> GetPagination()
        {
            return new PaginationOut()
            {
                Offset = Offset,
                Limit = Limit,
                Total = await new Count().UsingFilter(Filter)
            };
        }

    }
}
