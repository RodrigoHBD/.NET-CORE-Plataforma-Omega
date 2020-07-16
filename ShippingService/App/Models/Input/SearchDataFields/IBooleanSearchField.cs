using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Models.Input.SearchDataFields
{
    public interface IBooleanSearchField
    {
        public bool IsActive { get; set; }
        public bool Value { get; set; }
    }
}
