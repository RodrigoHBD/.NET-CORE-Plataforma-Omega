using SalesService.App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesService.App.Models.Input
{
    public class SearchSalesRequest
    {
        public StringSearchFilter PlatformSaleId { get; set; } = new StringSearchFilter();

        public StringSearchFilter ProductId { get; set; } = new StringSearchFilter();

        public PaginationIn Pagination { get; set; } 

        public SearchSalesRequest()
        {
            Pagination = new PaginationIn()
            {
                Limit = SaleEntity.SaleSearchDefaultLimit
            };
        }
    }
}
