using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesService.App.Boundries
{
    public class DAO
    {
        public SaleDAO SaleDAO { get; private set; } = new SaleDAO();
    }
}
