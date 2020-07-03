using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.App.Models.Input.UpdateFields
{
    interface IStringFieldUpdate
    {
        bool IsSet { get; }
        string Value { get; }
    }
}
