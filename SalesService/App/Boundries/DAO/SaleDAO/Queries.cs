using SalesService.App.Boundries.SaleDAOQueries;
using SalesService.App.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesService.App.Boundries.SaleDAOQueries
{
    public class Queries
    {
        public Register Register { get; private set; } = new Register();
        public Search Search { get; private set; } = new Search();
        public Count Count { get; private set; } = new Count();
        public GetByMarketplaceId GetByMarketplaceId { get; } = new GetByMarketplaceId();
    }
}
