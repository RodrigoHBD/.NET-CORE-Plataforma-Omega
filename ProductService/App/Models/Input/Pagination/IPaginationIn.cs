using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.Models.Input
{
    public interface IPaginationIn
    {
        int Offset { get; }
        int Limit { get; }
    }
}
