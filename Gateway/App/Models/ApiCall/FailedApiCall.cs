using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.App.Models
{
    public class FailedApiCall : ApiCallResult
    {
        public string FailureReason { get; set; } = "";
    }
}
