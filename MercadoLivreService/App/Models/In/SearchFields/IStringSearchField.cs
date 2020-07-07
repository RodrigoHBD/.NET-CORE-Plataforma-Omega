using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Models.SearchFields
{
    public interface IStringSearchField
    {
        bool IsActive { get; set; }
        string Value { get; set; }
    }
}
