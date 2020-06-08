using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.Correios.Models.Sro
{
    public class SroJsonResponse
    {
        public List<string> numero { get; set; }
        public List<string> sigla { get; set; }
        public List<string> nome { get; set; }
        public List<string> categoria { get; set; }
        public List<SroEvent> evento { get; set; }
    }

    public class SroEvent
    {
        public List<string> tipo { get; set; }
        public List<string> status { get; set; }
        public List<string> data { get; set; }
        public List<string> hora { get; set; }
        public List<string> descricao { get; set; }
        public List<string> detalhe { get; set; }
        public List<string> local { get; set; }
        public List<string> codigo { get; set; }
        public List<string> cidade { get; set; }
        public List<string> uf { get; set; }
        public List<SroEventDestination> destino { get; set; }
    }

    public class SroEventDestination
    {
        public List<string> local { get; set; } 
        public List<string> codigo { get; set; } 
        public List<string> cidade { get; set; } 
        public List<string> bairro { get; set; } 
        public List<string> uf { get; set; } 
    }
}
