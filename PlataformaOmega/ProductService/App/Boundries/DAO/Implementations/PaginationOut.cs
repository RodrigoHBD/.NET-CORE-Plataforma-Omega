using ProductService.App.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.Boundries.DAO
{
    public class PaginationOut : IPaginationOut
    {
        public int Offset { get; set; }

        public int Limit { get; set; }

        public int Total { get; set; }
    }
}
