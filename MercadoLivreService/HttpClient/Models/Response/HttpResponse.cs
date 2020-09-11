using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HttpClientLibrary
{
    public class HttpResponse
    {
        public int Status { get; set; }
        public string StatusMessage { get; set; }
        public string Data { get; set; }
    }
}
