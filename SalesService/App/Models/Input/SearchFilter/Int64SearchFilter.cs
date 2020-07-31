using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesService.App.Models.Input
{
    public class Int64SearchFilter : SearchFilter
    {
        public long Value { get; set; }
    }
}
