using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.ServerGrid.Models
{
    public class MLNotification
    {
        public string Resource { get; set; }
        public string UserId { get; set; }
        public string Topic { get; set; }
        public string RecivedAt { get; set; }
    }
}
