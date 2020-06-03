using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Models.Output
{
    public interface IPaginationOut
    {
        int Offset { get; }
        int Limit { get; }
        int Total { get; }
    }
}
