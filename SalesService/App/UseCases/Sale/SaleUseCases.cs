using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesService.App.UseCases
{
    public class SaleUseCases
    {
        public static CreateNewSale CreateNewSale { get; set; } = new CreateNewSale();
        public static RegisterSale RegisterSale { get; set; } = new RegisterSale();
        public static SearchSales SearchSales { get; set; } = new SearchSales();
        public static GetSaleByMarketplaceId GetSaleByMarketplaceId { get; } = new GetSaleByMarketplaceId();
    }
}
