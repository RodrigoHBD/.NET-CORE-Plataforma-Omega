using MercadoLivreService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Controllers.Implementations
{
    public class AddAccountRequest : IAddAccountRequest
    {
        public string Owner { get; set; } = "";

        public string Name { get; set; } = "";

        public string Description { get; set; } = "";

        public string AuthCode { get; set; } = "";
    }
}
