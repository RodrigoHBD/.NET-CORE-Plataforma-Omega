using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreLibrary.Models
{
    public class PackConversationStatusJson
    {
        public string path { get; set; }

        public string status { get; set; }

        public long? shipping_id { get; set; }
    }
}
