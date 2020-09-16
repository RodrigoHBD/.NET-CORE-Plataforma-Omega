using MercadoLivreService.App.Models.UpdateFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Models
{
    public class AccountUpdate
    {
        public StringFieldUpdate Email { get; set; } = new StringFieldUpdate();
        public StringFieldUpdate Nickname { get; set; } = new StringFieldUpdate();
        public StringFieldUpdate Name { get; set; } = new StringFieldUpdate();
        public StringFieldUpdate Description { get; set; } = new StringFieldUpdate();
    }
}
