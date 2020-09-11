using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreLibrary.Models
{
    public class OrderPaymentJson
    {
        //public int id { get; set; }

        public double transaction_amount { get; set; }

        public string currency_id { get; set; } = "";

        public string status { get; set; } = "";

        public string date_created { get; set; } = "";
    }
}
