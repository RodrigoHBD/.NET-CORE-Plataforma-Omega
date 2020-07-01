using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Models
{
    public class Location
    {
        public bool IsSet { get; set; } = false;
        public string State { get; set; } = "";
        public string City { get; set; } = "";
        public string Neighborhood { get; set; } = "";
        public string StreetName { get; set; } = "";
        public int StreetNumber { get; set; } = 0;
        public string Cep { get; set; } = "";
        public Location()
        {

        }
    }
}
