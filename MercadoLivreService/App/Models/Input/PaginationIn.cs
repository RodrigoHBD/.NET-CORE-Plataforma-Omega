﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Models.In
{
    public class PaginationIn
    {
        public int Offset { get; set; }

        public int Limit { get; set; }

    }
}
