using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreLibrary.Models
{
    public class OrderItemWrapperJson
    {
        public OrderItemJson item { get; set; } = new OrderItemJson();

        public int quantity { get; set; }

        public double unit_price { get; set; }

        public string currency_id { get; set; } = "";
    }
}
