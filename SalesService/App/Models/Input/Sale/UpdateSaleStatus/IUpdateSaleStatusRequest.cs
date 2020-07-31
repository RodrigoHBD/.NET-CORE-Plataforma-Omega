using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesService.App.Models;

namespace SalesService.App.Models.Input
{
    public interface IUpdateSaleStatusRequest
    {
        string Id { get; }
        SaleStatus Status { get; }
    }
}
