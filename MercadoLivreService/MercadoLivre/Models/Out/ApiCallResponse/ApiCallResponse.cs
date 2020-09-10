using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.MercadoLivreModels.Out
{
    public class ApiCallResponse
    {
        public bool IsOk { get; set; } = false;

        public dynamic DeserializedJson { get; set; } = null;

        public Exception Exception { get; set; } = null;
    }

}
