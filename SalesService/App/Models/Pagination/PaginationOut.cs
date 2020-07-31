using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesService.App.Models
{
    public class PaginationOut
    {
        public long Offset { get; set; }
        public long Limit { get; set; }
        public long Total { get; set; }
    }
}
