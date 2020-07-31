using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesService.App.Models.Input
{
    public class StringSearchFilter : SearchFilter
    {
        public string Value { get; set; }
    }
}
