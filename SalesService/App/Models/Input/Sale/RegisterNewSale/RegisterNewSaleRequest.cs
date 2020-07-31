using SalesService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesService.App.Models.Input
{
    public class RegisterSaleRequest
    {
        public string PlatformSaleId { get; set; }
        public string ProductId { get; set; }
        public int QuantitySold { get; set; }
        public string Plataform { get; set; }
        public SaleStatus Status { get; set; } 
        public List<SaleIncludedService> IncludedServices { get; set; } = new List<SaleIncludedService>();
        public List<SaleIncludedTax> IncludedTaxes { get; set; } = new List<SaleIncludedTax>();
        public TotalValueCalculationMatchConfig TotalValueCalculationConfig { get; } = new TotalValueCalculationMatchConfig();
    }

    public class TotalValueCalculationMatchConfig
    {
        public bool OverrideUnitaryPrice { get; } = false;
        public double UnitaryPrice { get; }
    }
}
