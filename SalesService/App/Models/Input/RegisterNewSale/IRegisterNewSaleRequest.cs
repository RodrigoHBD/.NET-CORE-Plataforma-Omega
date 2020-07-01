using SalesService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesService.App.Models.Input
{
    public interface IRegisterNewSaleRequest
    {
        string ProductId { get; }
        int QuantitySold { get; }
        SalePlataform Plataform { get; }
        SaleStatus Status { get; }
        List<IIncludedService> IncludedServices { get; }
        ITotalValueCalculationMatchConfig TotalValueCalculationConfig { get; }
    }

    public interface IIncludedService
    {
        string Name { get; }
        string Description { get; }
        double Price { get; }
    }

    public interface ITotalValueCalculationMatchConfig
    {
        bool GivenValueMustMatchWithCalculatedValue { get; }
        bool OverrideUnitaryPrice { get; }
        double TotalValue { get; }
        double UnitaryPrice { get; }
    }
}
