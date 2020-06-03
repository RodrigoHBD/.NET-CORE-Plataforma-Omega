using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Models.Input
{
    public interface IPaginationIn
    {
        int Offset { get; }
        int Limit { get; }
    }
}
