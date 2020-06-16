using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.Models.Input
{
    public interface IRegisterNewBrandRequest
    {
        string Name { get; }
        string Abbreviation { get; }
        string Cnpj { get; }
    }
}
