using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.Models.Input
{
    public interface ISearchIntDataField
    {
        bool IsActive { get; }
        string Value { get; }
        NumberOperatorMathLogic Operator { get; }
    }
}
