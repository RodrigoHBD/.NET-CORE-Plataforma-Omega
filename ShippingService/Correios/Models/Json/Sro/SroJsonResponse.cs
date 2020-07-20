using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.Correios.Models.Sro
{
    public class SroJsonResponse
    {
        public List<string> numero { get; set; } = new List<string>();
        public List<string> sigla { get; set; } = new List<string>();
        public List<string> nome { get; set; } = new List<string>();
        public List<string> categoria { get; set; } = new List<string>();
        public List<SroEvent> evento { get; set; } = new List<SroEvent>();
        public List<string> erro { get; set; } = new List<string>();
    }

    public class SroEvent
    {
        public List<string> tipo { get; set; } = new List<string>();
        public List<string> status { get; set; } = new List<string>();
        public List<string> data { get; set; } = new List<string>();
        public List<string> hora { get; set; } = new List<string>();
        public List<string> descricao { get; set; } = new List<string>();
        public List<string> detalhe { get; set; } = new List<string>();
        public List<string> local { get; set; } = new List<string>();
        public List<string> codigo { get; set; } = new List<string>();
        public List<string> cidade { get; set; } = new List<string>();
        public List<string> uf { get; set; } = new List<string>();
        public List<SroEventDestination> destino { get; set; } = new List<SroEventDestination>();
    }

    public class SroEventDestination
    {
        public List<string> local { get; set; } = new List<string>();
        public List<string> codigo { get; set; } = new List<string>();
        public List<string> cidade { get; set; } = new List<string>();
        public List<string> bairro { get; set; } = new List<string>();
        public List<string> uf { get; set; } = new List<string>();
    }
}
