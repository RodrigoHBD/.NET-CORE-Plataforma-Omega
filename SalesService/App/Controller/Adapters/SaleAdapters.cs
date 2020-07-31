using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesService.App.Controller.Adapters
{
    public class SaleAdapters
    {
        public static RegisterSaleReqAdapter RegisterSaleRequest { get; } = new RegisterSaleReqAdapter();
    }
}
