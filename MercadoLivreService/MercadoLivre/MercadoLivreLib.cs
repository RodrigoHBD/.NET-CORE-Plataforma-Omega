using MercadoLivreLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MercadoLivreLibrary
{
    public class MercadoLivreLib
    {
        public static Credentials Credentials { get; } = new Credentials();

        public static MercadoLivreMethods Methods { get; private set; } = new MercadoLivreMethods();
    }
}
