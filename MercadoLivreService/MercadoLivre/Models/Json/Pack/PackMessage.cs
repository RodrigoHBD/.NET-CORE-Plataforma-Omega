using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreLibrary.Models
{
    public class PackMessage
    {
        public string id { get; set; }

        public string status { get; set; }

        public string text { get; set; }

        public PackMessageSender from { get; set; }

        public PackMessageDates message_dates { get; set; }
    }

}
