using SalesService.App.Boundries.SaleDAOQueries;
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
    }
}
