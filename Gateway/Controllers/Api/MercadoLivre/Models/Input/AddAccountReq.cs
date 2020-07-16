using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Controllers.Api.MercadoLivreModels.Input
{
    public class AddAccountReq
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string AuthCode { get; set; } = "";
    }
}
