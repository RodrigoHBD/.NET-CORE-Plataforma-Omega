using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.App.Models
{
    public class ApiCallResult
    {
        public bool IsSuccessful { get; set; } = false;
        public bool HasData { get; set; }
        public ApiCallResultData Data { get; set; } = new ApiCallResultData();
    }

    public class ApiCallResultData
    {
        public bool HasContent { get; set; }
        public dynamic Content { get; set; }
    }
}
