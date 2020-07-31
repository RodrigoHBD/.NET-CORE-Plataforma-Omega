using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Controllers.Api.MercadoLivreModels.Input
{
    public class Notification
    {
        public string resource { get; set; } 
        public long user_id { get; set; }
        public string topic { get; set; }
        public string received { get; set; }
        public string sent { get; set; }
    }
}
