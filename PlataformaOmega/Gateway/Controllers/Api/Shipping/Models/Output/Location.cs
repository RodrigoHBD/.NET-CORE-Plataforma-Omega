using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Controllers.Api.Shipping.Models.Output
{
    public class Location
    {
        public string State { get; set; } = "";
        public string City { get; set; } = "";
        public string Cep { get; set; } = "";
        public string StreetName { get; set; } = "";
        public int StreetNumber { get; set; } = 0;
    }
}
