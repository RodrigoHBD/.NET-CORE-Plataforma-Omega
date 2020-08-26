using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Controllers.Common.Models
{
    public class BooleanSearchFilter
    {
        public bool IsActive { get; set; } = false;
        public bool Value { get; set; } = false;
    }
}
