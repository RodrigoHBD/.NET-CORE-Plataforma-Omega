using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Controllers.Api.Models
{
    public class PaginationOut
    {
        public int Offset { get; set; }
        public int Limit { get; set; }
        public int Total { get; set; }
    }
}
