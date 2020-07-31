using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesService.App.Models
{
    public class PaginationIn
    {
        public int Offset { get; set; } = 0;
        public int Limit { get; set; }
    }
}
