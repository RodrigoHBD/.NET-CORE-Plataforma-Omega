using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Models.Input.SearchDataFields
{
    public interface IStringSearchField
    {
        bool IsActive { get; set; }
        string Value  { get; set; }
    }
}
