using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.MercadoLivreModels.Out
{
    public class OrderDetailsJson
    {
        public List<OrderDetailJson> results { get; set; } = new List<OrderDetailJson>();
        public OrderDetailsPaging paging { get; set; } = new OrderDetailsPaging();
    }

    public class OrderDetailsPaging
    {
        public int total { get; set; }
        public int offset { get; set; }
        public int limit { get; set; }
    }

    public class OrderDetailJson
    {
        public long id { get; set; }
        public string status { get; set; } = "";
        //public string status_detail { get; set; } = "";
        public string date_created { get; set; } = "";
        public string date_closed { get; set; } = "";
        public OrderDetailShipping shipping { get; set; } = new OrderDetailShipping();
        public List<OrderDetailsJsonItems> order_items { get; set; } = new List<OrderDetailsJsonItems>();
        public double total_amount { get; set; }
        public string currency_id { get; set; } = "";
        public OrderDetailsJsonBuyer buyer { get; set; } = new OrderDetailsJsonBuyer();
        public List<OrderDetailsJsonPayment> payments { get; set; } = new List<OrderDetailsJsonPayment>();
    }

    public class OrderDetailsJsonItems
    {
        public OrderDetailsJsonItem item { get; set; } = new OrderDetailsJsonItem();
        public int quantity { get; set; }
        public double unit_price { get; set; }
        public string currency_id { get; set; } = "";
    }

    public class OrderDetailsJsonItem
    {
        public string id { get; set; } = "";
        public string title { get; set; } = "";
        public long? variation_id { get; set; } 
        public string? seller_sku { get; set; }
    }

    public class OrderDetailsJsonBuyer
    {
        public long id { get; set; } 
        public string nickname { get; set; } = "";
        public string email { get; set; } = "";
        public string first_name { get; set; } = "";
        public string last_name { get; set; } = "";
        public OrderDetailsJsonBuyerBillingInfo billing_info { get; set; } = new OrderDetailsJsonBuyerBillingInfo();
    }

    public class OrderDetailsJsonBuyerBillingInfo
    {
        public string doc_type { get; set; } = "";
        public string doc_number { get; set; } = "";
    }

    public class OrderDetailsJsonPayment
    {
        //public int id { get; set; }
        public double transaction_amount { get; set; }
        public string currency_id { get; set; } = "";
        public string status { get; set; } = "";
        public string date_created { get; set; } = "";
    }

    public class OrderDetailsJsonShipping
    {
        public int id { get; set; }
    }

    public class OrderDetailShipping
    {
        public long id { get; set; }
        public string substatus { get; set; } = "";
    }


}
