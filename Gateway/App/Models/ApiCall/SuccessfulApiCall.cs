using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.App.Models
{
    public class SuccessfulApiCall : ApiCallResult
    {
        public string Message { get; set; } = "Chamada API bem sucedida.";
    }
}
