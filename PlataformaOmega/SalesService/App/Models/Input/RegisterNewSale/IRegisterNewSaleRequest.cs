using SalesService.App.Models.Sale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesService.App.Models.Input.RegisterNewSale
{
    public interface IRegisterNewSaleRequest
    {
        string ProductId { get; }
        decimal TotalValue { get; }
        int QuantitySold { get; }
        SalePlataform Plataform { get; }
    }
}
