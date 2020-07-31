using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesService.App.Models.Output
{
    public class SalesList
    {
        public List<Sale> Data { get; set; } = new List<Sale>();

        public PaginationOut Pagination { get; set; } = new PaginationOut();
    }
}
