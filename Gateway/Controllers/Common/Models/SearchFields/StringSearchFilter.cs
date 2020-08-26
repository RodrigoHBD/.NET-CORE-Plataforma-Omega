using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Controllers.Common.Models
{
    public class StringSearchFilter 
    {
        public bool IsActive { get; set; } = false;
        public string Value { get; set; } = "";
    }
}
