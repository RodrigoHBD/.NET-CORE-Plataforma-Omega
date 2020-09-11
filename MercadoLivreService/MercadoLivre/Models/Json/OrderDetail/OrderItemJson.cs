using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreLibrary.Models
{
    public class OrderItemJson
    {
        public string id { get; set; } = "";

        public string title { get; set; } = "";

        public long? variation_id { get; set; }

        public string? seller_sku { get; set; }
    }
}
