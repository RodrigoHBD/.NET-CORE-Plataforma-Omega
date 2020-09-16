using MercadoLivreLibrary.Methods.Pack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreLibrary.Methods
{
    public class PackMethods
    {
        public Get Get { get { return new Get(); } }

        public AddMessage AddMessage { get { return new AddMessage(); } }
    }
}
