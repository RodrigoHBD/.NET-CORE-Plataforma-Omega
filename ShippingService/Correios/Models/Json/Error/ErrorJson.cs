using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.Correios.Models.Error
{
    public class ErrorJson
    {
        public List<string> numero { get; set; } = new List<string>();
        public List<string> erro { get; set; } = new List<string>();
    }
}
