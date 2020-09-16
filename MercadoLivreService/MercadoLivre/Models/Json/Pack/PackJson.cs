using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreLibrary.Models
{
    public class PackJson
    {
        public PagingJson paging { get; set; }

        public PackConversationStatusJson conversation_status { get; set; }

        public List<PackMessage> messages { get; set; }
    }
}
