﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreLibrary.Models
{
    public class OrderDetailWrapperJson
    {
        public List<OrderDetailJson> results { get; set; } = new List<OrderDetailJson>();

        public PagingJson paging { get; set; } = new PagingJson();
    }

}
