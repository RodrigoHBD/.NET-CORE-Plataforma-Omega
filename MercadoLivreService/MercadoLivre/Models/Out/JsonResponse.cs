using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreLibrary.Models
{
    public class JsonResponse
    {
        public bool IsOk { get; set; } = false;

        public dynamic DeserializedJson { get; set; } = null;

        public Exception Exception { get; set; } = null;
    }

}
