using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreLibrary.Models.Input.Pack
{
    public class MLLAddMessage
    {
        public long SenderId { get; set; }

        public long ReceiverId { get; set; }

        public long PackId { get; set; }

        public string SenderEmail { get; set; }

        public string Token { get; set; }

        public string MessageText { get; set; }
    }
}
