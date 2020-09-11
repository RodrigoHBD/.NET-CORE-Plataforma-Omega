using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreLibrary.Models
{
    public class OrderDetailJson
    {
        public long id { get; set; }

        public long? pack_id { get; set; }

        public string status { get; set; } = "";

        public string date_created { get; set; } = "";

        public string date_closed { get; set; } = "";

        public OrderShippingJson shipping { get; set; } = new OrderShippingJson();

        public List<OrderItemWrapperJson> order_items { get; set; } = new List<OrderItemWrapperJson>();

        public double total_amount { get; set; }

        public string currency_id { get; set; } = "";

        public OrderBuyerJson buyer { get; set; } = new OrderBuyerJson();

        public List<OrderPaymentJson> payments { get; set; } = new List<OrderPaymentJson>();
    }
}
