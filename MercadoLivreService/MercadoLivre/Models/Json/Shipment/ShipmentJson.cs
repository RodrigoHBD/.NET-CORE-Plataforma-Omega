using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.MercadoLivre.Models
{
    public class ShipmentJson
    {
        public long id { get; set; }

        public long order_id { get; set; }

        public string tracking_method { get; set; } = "";

        public string status { get; set; } = "";

        public string substatus { get; set; } = "";

        public string? tracking_number { get; set; } 
    }
}
