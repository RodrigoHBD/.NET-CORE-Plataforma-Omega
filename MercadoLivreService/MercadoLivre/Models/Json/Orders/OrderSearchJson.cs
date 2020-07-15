using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.MercadoLivreModels.Out
{
    public class OrderSearchJson
    {
        public string query { get; set; } = "";
        public List<OrderDetailsJson> results { get; set; } = new List<OrderDetailsJson>();
        public PaginationJson paging { get; set; } = new PaginationJson();
    } 
}
