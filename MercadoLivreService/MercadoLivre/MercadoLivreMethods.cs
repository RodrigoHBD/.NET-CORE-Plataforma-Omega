﻿using MercadoLivreLibrary.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreLibrary
{
    public class MercadoLivreMethods
    {
        public AccountMethods Account { get; set; } = new AccountMethods();

        public TokensMethods Tokens { get; set; } = new TokensMethods();

        public OrderMethods Order { get; } = new OrderMethods();

        public ShippingMethods Shipment { get; } = new ShippingMethods();

        public PackMethods Pack { get; } = new PackMethods();
    }
}
