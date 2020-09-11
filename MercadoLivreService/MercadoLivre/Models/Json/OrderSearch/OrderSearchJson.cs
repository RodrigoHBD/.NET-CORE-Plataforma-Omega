using MercadoLivreLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreLibrary
{
    public class OrderSearchJson
    {
        public string query { get; set; } 

        public List<OrderDetailJson> results { get; set; } = new List<OrderDetailJson>();

        public PagingJson paging { get; set; } = new PagingJson();
    } 
}
