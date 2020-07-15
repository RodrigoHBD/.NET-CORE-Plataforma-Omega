using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.MercadoLivreModels.Out
{
    public class OwnedAddDetailsJson
    {
        public string id { get; set; }
        public string site_id { get; set; }
        public string title { get; set; }
        public string subtitle { get; set; }
        public int seller_id { get; set; }
        public string category_id { get; set; }
        public double price { get; set; }
        public double base_price { get; set; }
        public double original_price { get; set; }
        public string currency_id { get; set; }
        public int initial_quantity { get; set; }
        public int available_quantity { get; set; }
        public int sold_quantity { get; set; }
        public string date_created { get; set; }
        public string last_updated { get; set; }
    }
}
