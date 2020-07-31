using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Models
{
    public class StringFieldUpdate
    {
        public bool MustUpdate { get; set; } = false;
        public string Value { get; set; } = "";
    }
}
