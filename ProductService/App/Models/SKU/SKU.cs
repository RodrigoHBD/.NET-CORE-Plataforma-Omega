using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.Models.SKU
{
    public class SKU
    {
        //public ObjectId Id { get; set; }
        public List<string> SKUNumber { get; set; }
        public string BoundPlatform { get; set; }
        public string IdProduto { get; set; }
        // Referencia aos anuncios
    }
}
