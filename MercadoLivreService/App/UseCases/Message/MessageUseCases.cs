﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.UseCases
{
    public class MessageUseCases
    {
        public static SendPostSaleMessage SendPostSaleMessage 
        { get { return new SendPostSaleMessage(); } }


    }
}
