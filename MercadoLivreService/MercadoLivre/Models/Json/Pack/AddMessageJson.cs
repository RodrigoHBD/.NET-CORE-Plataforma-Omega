using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreLibrary.Models
{
    public class AddMessageJson
    {
        public string text { get; set; }

        public AddMessageSenderJson from { get; set; } 

        public AddMessageReceiverJson to { get; set; }

        public List<string> attachments { get; set; } = null;
    }

    public class AddMessageSenderJson
    {
        public string user_id { get; set; }

        public string email { get; set; }
    }

    public class AddMessageReceiverJson
    {
        public string user_id { get; set; }
    }
}
