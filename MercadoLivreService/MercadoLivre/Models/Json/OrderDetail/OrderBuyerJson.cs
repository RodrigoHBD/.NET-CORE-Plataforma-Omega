using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreLibrary.Models
{
    public class OrderBuyerJson
    {
        public long id { get; set; }

        public string nickname { get; set; } = "";

        public string email { get; set; } = "";

        public string first_name { get; set; } = "";

        public string last_name { get; set; } = "";

        public OrderBuyerBillingData billing_info { get; set; } = new OrderBuyerBillingData();
    }

    public class OrderBuyerBillingData
    {
        public string doc_type { get; set; } = "";

        public string doc_number { get; set; } = "";
    }
}
