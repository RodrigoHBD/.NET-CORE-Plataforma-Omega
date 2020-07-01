using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.Models.Input
{
    public interface ISearchNumberOperator
    {
        
    }

    public enum NumberOperatorMathLogic
    {
        LesserThan = 0,
        EqualsTo = 1,
        GreaterThan = 2,
        EqualsOrGreater = 3,
        EqualsOrLesserThan = 4
    }
}
