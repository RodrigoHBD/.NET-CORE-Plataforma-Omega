using MercadoLivreService.App.Models.SearchFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Controllers.Implementations
{
    public class StringSearchField : Models.SearchFields.StringSearchField
    {
        public bool IsActive { get; set; } = false;

        public string Value { get; set; } = "";

        public StringSearchField(string value = "")
        {
            if(value.Length > 0)
            {
                Value = value;
                IsActive = true;
            }
        }
    }
}
