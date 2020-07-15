using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.MercadoLivreModels.Out
{
    public class ErrorJson
    {
        public string message { get; set; } = "";
        public string error { get; set; } = "";
        public int status { get; set; }
        public List<string> cause { get; set; } = new List<string>();
    }
}
